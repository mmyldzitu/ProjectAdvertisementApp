using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Dtos.AdvertisementDtos;
using AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Controllers
{
    [Authorize(Roles="Admin")]
    public class ApplicationController : Controller
    {
        private readonly IAdvertisementService _advertisementService;

        public ApplicationController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> List()
        {
            var data = await _advertisementService.GetAllAsync();
            return this.ResponseView(data);
        }
        public IActionResult CreateAdvertisement()
        {
            return View(new AdvertisementCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvertisement(AdvertisementCreateDto dto)
        {
          var response= await _advertisementService.CreateAsync(dto);
            return this.ResponseRedirectAction(response, "List");
        }
        public async Task<IActionResult> UpdateAdvertisement(int id)
        {
            var response = await _advertisementService.GetByIdAsync<AdvertisementUpdateDto>(id);
            return this.ResponseView(response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAdvertisement(AdvertisementUpdateDto dto)
        {
            var response = await _advertisementService.UpdateAsync(dto);
            return this.ResponseRedirectAction(response, "List");
        }
        public async Task<IActionResult> RemoveAdvertisement(int id)
        {
            var response = await _advertisementService.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "List");
        }
    }
}
