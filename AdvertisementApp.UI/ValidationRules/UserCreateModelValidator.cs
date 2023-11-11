using AdvertisementApp.UI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator:AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim Boş Geçilemez");
            RuleFor(x => x.SecondName).NotEmpty().WithMessage("Soyisim Boş Geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lüfen Şifrenizi Giriniz");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Şifreniz 3 Karakterden Az Olamaz");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Şifreleriniz Uyuşmamaktadır");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı Adı 3 Karakterden Daha Kısa Olamaz");
            RuleFor(x => x.GenderID).NotEmpty().WithMessage("Lütfen bir cinsiyet seçiniz");
            

            RuleFor(x => 
            new { x.UserName,x.FirstName}).Must(x=>  CanNotfirstname(x.UserName,x.FirstName)).WithMessage("Kullanıcı Adı isminizi içeremez!").When(x=>x.UserName!=null && x.FirstName!=null);
           
      
        }

        private bool CanNotfirstname(string userName,string firstName)
        {
            return !userName.Contains(firstName);
        }

       
    }
}
