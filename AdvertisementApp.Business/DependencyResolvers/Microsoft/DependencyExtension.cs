﻿using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Business.Mappings;
using AdvertisementApp.Business.Services;
using AdvertisementApp.Business.ValidationRules.Advertisement;
using AdvertisementApp.Business.ValidationRules.AdvertisementAppUser;
using AdvertisementApp.Business.ValidationRules.AppUser;
using AdvertisementApp.Business.ValidationRules.Gender;
using AdvertisementApp.Business.ValidationRules.ProvideedService;
using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.AdvertisementAppUserDtos;
using AdvertisementApp.Dtos.AdvertisementDtos;
using AdvertisementApp.Dtos.AppUserDtos;
using AdvertisementApp.Dtos.GenderDtos;
using AdvertisementApp.Dtos.ProvidedServiceDtos;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.DependencyResolvers.Microsoft
{
   public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt => {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
           


            services.AddScoped<IUow, Uow>();
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();

            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
            services.AddTransient <IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateDtoValidator>();

            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserService>();
        }
        
    }
}
