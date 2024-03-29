﻿using System.Globalization;
using System.Reflection;
using CloudinaryDotNet;
using MDMS.Data;
using Mdms.Data.Models;
using MDMS.Data.Seeding;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.Areas.Identity.Pages.Account;
using MDMS.Web.BindingModels.Vehicle.Create;
using MDMS.Web.Extensions;
using MDMS.Web.ViewModels.Vehicle.All;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MDMS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<MdmsDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<MdmsUserRoleSeeder>();
            services.AddScoped<MdmsRootUserSeeder>();
            services.AddScoped<RepairedSystemSeeder>();
            services.AddScoped<ReportTypeSeeder>();
            services.AddScoped<VehicleTypeSeeder>();

            services.AddIdentity<MdmsUser, IdentityRole>()
                .AddEntityFrameworkStores<MdmsDbContext>()
                .AddDefaultTokenProviders();


            //Cloud setup
            Account cloudinaryCredentials = new Account(
                this.Configuration["Cloudinary:CloudName"],
                this.Configuration["Cloudinary:ApiKey"],
                this.Configuration["Cloudinary:ApiSecret"]);

            Cloudinary cloudinaryUtility = new Cloudinary(cloudinaryCredentials);

            services.AddSingleton(cloudinaryUtility);
            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;

                options.User.RequireUniqueEmail = true;
            });

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPartService, PartService>();
            services.AddTransient<IRepairService, RepairService>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IReportService, ReportService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(VehicleCreateBindingModel).GetTypeInfo().Assembly,
                typeof(VehicleAllViewModel).GetTypeInfo().Assembly,
                typeof(MonthlySalaryViewModel).GetTypeInfo().Assembly,
                typeof(VehicleServiceModel).GetTypeInfo().Assembly);

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            if (env.IsDevelopment())
            { 
                //
               // app.UseDeveloperExceptionPage();
               // app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions() { SourceCodeLineCount = 100 });
               app.UseExceptionHandler("/Home/Error");
               app.UseHsts();
               
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHsts();
            app.UseDatabaseSeeding();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areasWithName", template: "{area:exists}/{controller=Home}/{action=Index}/{name?}");
                routes.MapRoute(name: "areas", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "defaultWithName", template: "{controller=Home}/{action=Index}/{name?}");
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
