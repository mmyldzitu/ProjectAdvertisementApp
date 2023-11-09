using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Entities
{
    public class AdvertisementAppUser:BaseEntity
    {
        public int AdvertisementID { get; set; }
        public Advertisement Advertisement { get; set; }


        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }


        public int AdvertisementUserStatusID { get; set; }
        public AdvertisementAppUserStatus AdvertisementAppUserStatus { get; set; }



        public int MilitaryStatusID { get; set; }
        public MilitaryStatus MilitaryStatus { get; set; }
        public DateTime? EndDate { get; set; }


        public int WorkExperience { get; set; }
        public string CvPath { get; set; }



    }
}
