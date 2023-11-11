﻿using AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Dtos.AppUserDtos
{
    public class AppUserListDto:IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }
       
        public string phoneNumber { get; set; }
        public string Password { get; set; }

        public int GenderID { get; set; }

    }
}
