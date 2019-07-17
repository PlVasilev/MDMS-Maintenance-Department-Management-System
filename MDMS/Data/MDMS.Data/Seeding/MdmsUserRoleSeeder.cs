using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Data.Seeding
{
   public class MdmsUserRoleSeeder : ISeeder
    {
        private readonly MdmsDbContext _context;

        public MdmsUserRoleSeeder(MdmsDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.Roles.CountAsync() <= 1)
            {
               // _context.Roles.Add(new IdentityRole() { Name = "Root", NormalizedName = "ROOT" });
                _context.Roles.Add(new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" });
                _context.Roles.Add(new IdentityRole() { Name = "User", NormalizedName = "USER" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
