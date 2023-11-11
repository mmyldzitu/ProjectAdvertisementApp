using AdvertisementApp.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.ValidationRules.AppUser
{
    public class AppUserUpdateDtoValidator:AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim Kısmı Boş Geçilemez");
            RuleFor(x => x.SecondName).NotEmpty().WithMessage("Soyisim Kısmı Boş Geçilemez");
            RuleFor(x => x.GenderID).NotEmpty().WithMessage("Cinsiyet Kısmı BOş Geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola Kısmı Boş Geçilemez");
            RuleFor(x => x.phoneNumber).NotEmpty().WithMessage("Telefon Numarası Kısmı Boş Geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı İsmi Boş Geçilemez");
        }
    }
}
