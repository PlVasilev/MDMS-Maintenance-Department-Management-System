using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mdms.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace MDMS.Data.Seeding
{
   public class MdmsRootUserSeeder : ISeeder
    {
        private readonly UserManager<MdmsUser> _userManager;
        private readonly MdmsDbContext _context;


        public MdmsRootUserSeeder(UserManager<MdmsUser> userManager, MdmsDbContext context)
        {
            this._userManager = userManager;
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.Users.CountAsync() == 0)
            {
                var user = new MdmsUser
                {
                    UserName = "root",
                    Email = "root@eventures.com",
                    FirstName = "Root",
                    LastName = "Root",
                    BaseSalary = 0,
                    AdditionalOnHourPayment = 0,
                    SecurityStamp = Guid.NewGuid().ToString()

                };

                var rootRole = _context.Roles.FirstOrDefault(x => x.Name == "Root");

                if (rootRole == null)
                {
                    _context.Roles.Add(new IdentityRole() { Name = "Root", NormalizedName = "ROOT" });
                    _context.SaveChanges();
                }

                await _userManager.CreateAsync(user, "root");

                await _userManager.AddToRoleAsync(user, "Root");

            }
        }
    }
}
