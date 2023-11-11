using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Models
{
    public class UserCreateModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }

        public string phoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        public int GenderID { get; set; }
        public SelectList Genders { get; set; }
    }
}
