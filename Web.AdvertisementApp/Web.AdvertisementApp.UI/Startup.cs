﻿using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.AdvertisementApp.Business.DependencyResolvers.Microsoft;
using Web.AdvertisementApp.Business.Helpers;
using Web.AdvertisementApp.DataAccess.Contexts;
using Web.AdvertisementApp.UI.Mappings.AutoMapper;
using Web.AdvertisementApp.UI.Models;
using Web.AdvertisementApp.UI.ValidationRules;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Web.AdvertisementApp.Business.Services;

namespace Web.AdvertisementApp.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseNpgsql(Configuration.GetConnectionString("Local"));
            });

            services.AddDependencies(Configuration);
            services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt => {
        opt.Cookie.Name = "FBUCookie";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
        opt.ExpireTimeSpan = TimeSpan.FromDays(20);
        opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/SignIn");
        opt.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Account/Logout");
        opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/AccessDenied");
    });

            services.AddControllersWithViews();

            var profiles = ProfileHelper.GetProfiles();

            profiles.Add(new UserCreateModelProfile());

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
