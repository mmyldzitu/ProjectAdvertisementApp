﻿using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;

        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator)
        {
            _genderService = genderService;
            _userCreateModelValidator = userCreateModelValidator;
        }

        public async Task<ActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new UserCreateModel()
            {
                Genders = new SelectList(response.Data, "Id", "Definition")
        };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _userCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                return View(model);

            }
            
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition",model.GenderID);

            return View(model);
        }
    }
}