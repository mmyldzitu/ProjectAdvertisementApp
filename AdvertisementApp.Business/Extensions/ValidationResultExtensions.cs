using AdvertisementApp.Common;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtensions
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new List<CustomValidationError>();
            foreach(var item in validationResult.Errors)
            {
                errors.Add(new() { 
                
                ErrorMessage=item.ErrorMessage,
                PropertyName=item.PropertyName
                
                
                });
            }
            return errors;  
        }
    }
}
