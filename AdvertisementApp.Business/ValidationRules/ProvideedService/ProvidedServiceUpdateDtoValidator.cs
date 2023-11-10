using AdvertisementApp.Dtos.ProvidedServiceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.ValidationRules.ProvideedService
{
    public class ProvidedServiceUpdateDtoValidator:AbstractValidator<ProvidedServiceUpdateDto>
    {
        public ProvidedServiceUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Kısmı Boş Geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Kısmı Boş Geçilemez");
            RuleFor(x => x.ImagePath).NotEmpty().WithMessage("Dosya Yolu Boş Geçilemez");
        }
    }
}
