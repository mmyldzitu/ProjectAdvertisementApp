using AdvertisementApp.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseRedirectAction<T>(this Controller controller, IResponse<T> response, string actionName, string controllerName="")
        {
            //örneğin update veya create
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach(var error in response.ValidationError)
                {
                    controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return controller.View(response.Data);
            }
            if (string.IsNullOrWhiteSpace(controllerName))
            {
                return controller.RedirectToAction(actionName);

            }
            else
            {
                return controller.RedirectToAction(actionName, controllerName);
            }
        }
        //örneğin getbyıd
        public static IActionResult ResponseView<T>(this Controller contoller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return contoller.NotFound();
            }
            return contoller.View(response.Data);
        }
        //örneğin remove
        public static IActionResult ResponseRedirectAction(this Controller controller, IResponse response, string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.RedirectToAction(actionName);

        }
    }
}
