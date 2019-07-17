using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MDMS.Data;
using MDMS.Data.Seeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MDMS.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseDatabaseSeeding(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MdmsDbContext>();
                context.Database.EnsureCreated();

                Assembly.GetAssembly(typeof(MdmsDbContext))
                    .GetTypes()
                    .Where(type => typeof(ISeeder).IsAssignableFrom(type))
                    .Where(type => type.IsClass)
                    .Select(type => (ISeeder)serviceScope.ServiceProvider.GetRequiredService(type))
                    .ToList()
                    .ForEach(seeder => seeder.Seed().GetAwaiter().GetResult());
            }
        }
    }
}
