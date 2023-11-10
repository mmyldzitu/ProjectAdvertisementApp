using AdvertisementApp.Dtos.ProvidedServiceDtos;
using AdvertisementApp.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Mappings
{
   public class ProvidedServiceProfile: Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedServiceCreateDto, ProvidedServices>().ReverseMap();
            CreateMap<ProvidedServiceUpdateDto, ProvidedServices>().ReverseMap();
            CreateMap<ProvidedServiceListDto, ProvidedServices>().ReverseMap();
        }
    }
}
