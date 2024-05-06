using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

using Web.AdvertisementApp.Business.ValidationRules;
using Web.AdvertisementApp.DataAccess.Contexts;
using Web.AdvertisementApp.DataAccess.UnitOfWork;
using Web.AdvertisementApp.Dtos;


namespace Web.AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddScoped<IUow, Uow>();

           


        }

    }

}