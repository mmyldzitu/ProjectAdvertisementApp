using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Entities
{
    public class AppUser:BaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string phoneNumber { get; set; }
        public int GenderID { get; set; }
        public Gender Gender { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
