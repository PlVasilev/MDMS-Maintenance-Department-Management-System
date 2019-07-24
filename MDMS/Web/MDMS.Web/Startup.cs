using System.Globalization;
using System.Threading.Tasks;
using CloudinaryDotNet;
using MDMS.Data;
using Mdms.Data.Models;
using MDMS.Data.Seeding;
using MDMS.Services;
using MDMS.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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


            //Cloud
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

            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //using (var serviceScope = app.ApplicationServices.CreateScope())
            //{
            //    using (var context = serviceScope.ServiceProvider.GetRequiredService<MdmsDbContext>())
            //    {
            //        context.Database.EnsureCreated();
            //
            //        if (!context.Roles.Any())
            //        {
            //            context.Add(new IdentityRole() {Name = "Admin"});
            //            context.Add(new IdentityRole() {Name = "User"});
            //        }
            //    }
            //}
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
           
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            // app.UseExceptionHandler("/Home/Error");
            app.UseHsts();

            app.UseDatabaseSeeding();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areas", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
