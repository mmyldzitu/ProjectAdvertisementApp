﻿using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos.AdvertisementAppUserDtos;
using AdvertisementApp.Dtos.AppUserDtos;
using AdvertisementApp.Dtos.MilitaryStatus;
using AdvertisementApp.UI.Extensions;
using AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IAdvertisementAppUserService _advertisementAppUserService;

        public AdvertisementController(IAppUserService appUserService, IAdvertisementAppUserService advertisementAppUserService)
        {
            _appUserService = appUserService;
            _advertisementAppUserService = advertisementAppUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="Member")]
        public async Task<IActionResult> Send(int advertisementId)
        {
            var userID = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userID);
            ViewBag.genderId = userResponse.Data.GenderID;
            var items= Enum.GetValues(typeof(MilitaryStatusType));
            var list = new List<MilitaryStatusListDto>();
            foreach(int item in items)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                }) ;

            }
            ViewBag.militaryStatus = new SelectList(list, "Id", "Definition");
            return View(new AdvertisementAppUserCreateModel { 
            AdvertisementId=advertisementId,
            AppUserId=userID,

            });
        }
        [HttpPost]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModel model)
        {
            AdvertisementAppUserCreateDto dto = new();

            if (model.CvFile != null)
            {
                var fileName = Guid.NewGuid().ToString();
                var extname = Path.GetExtension(model.CvFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cvFiles",fileName+extname);
                var stream = new FileStream(path, FileMode.Create);
                await model.CvFile.CopyToAsync(stream);
                dto.CvPath = path;
                 
            }
            dto.AdvertisementAppUserStatusId = model.AdvertisementAppUserStatusId;
            dto.AdvertisementId = model.AdvertisementId;
            dto.AppUserId = model.AppUserId;
            dto.EndDate = model.EndDate;
            dto.MilitaryStatusId = model.MilitaryStatusId;
            dto.WorkExperience = model.WorkExperience;
            var response = await _advertisementAppUserService.CreateAsync(dto);
            if (response.ResponseType == Common.ResponseType.ValidationError)
            {
                foreach(var error in response.ValidationError)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("HumanResource", "Home");
            }
        }

    }
}