using AdvertisementApp.Dtos.ProvidedServiceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.ValidationRules.ProvideedService
{
    public class ProvidedServiceCreateDtoValidator:AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServiceCreateDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmı boş geçilemez");
            RuleFor(x => x.ImagePath).NotEmpty().WithMessage("Görsel Dosya Yolu Boş Geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Kısmı Boş Geçilemez");

        }
    }
}
