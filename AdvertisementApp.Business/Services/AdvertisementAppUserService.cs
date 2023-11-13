using AdvertisementApp.Business.Extensions;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.AdvertisementAppUserDtos;
using AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Services
{
    public class AdvertisementAppUserService:IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createDtoValidator;
        private readonly IMapper _mapper;

        public AdvertisementAppUserService(IUow uow, IValidator<AdvertisementAppUserCreateDto> createDtoValidator, IMapper mapper)
        {
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _mapper = mapper;
        }
        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var control = await _uow.GetRepository<AdvertisementAppUser>().FindByFilterAsync(x => x.AppUserID == dto.AppUserId && x.AdvertisementID == dto.AdvertisementId);
                if (control == null)
                {
                    var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
                    await _uow.SaveChangesAsync();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }
                else
                {
                    List<CustomValidationError> errors = new List<CustomValidationError>{
                        new CustomValidationError
                    {
                        ErrorMessage = "Aktif Başvuru Süreci İçinde Olduğunuz İlana Tekrar Başvuramazsınız",
                        PropertyName = ""

                    } 
                    } ;
                    return new Response<AdvertisementAppUserCreateDto>(dto, errors);
                }
             
                //business
            }
            else
            {
                return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
            }
        }
    }
}
