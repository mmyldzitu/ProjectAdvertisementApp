using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos.AdvertisementAppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.ValidationRules.AdvertisementAppUser
{
   public  class AdvertisementAppUserCreateDtoValidator:AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            RuleFor(x => x.AdvertisementUserStatusID).NotEmpty();
            RuleFor(x => x.AdvertisementId).NotEmpty();
            RuleFor(x => x.AppUserId).NotEmpty();
            RuleFor(x => x.CvPath).NotEmpty().WithMessage("Lütfen Bir Özgeçmiş Dosyası Yükleyiniz");
            RuleFor(x => x.EndDate).NotEmpty().When(x => x.MilitaryStatusId == (int)MilitaryStatusType.Tecilli).WithMessage("Lütfen Tecil Tarihinizi Giriniz");
            
        }
    }
}
