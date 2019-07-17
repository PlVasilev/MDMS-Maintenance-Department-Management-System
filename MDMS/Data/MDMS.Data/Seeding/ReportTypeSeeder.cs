using System.Threading.Tasks;
using MDMS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Data.Seeding
{
   public class ReportTypeSeeder
    {
        private readonly MdmsDbContext _context;

        public ReportTypeSeeder(MdmsDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.ReportTypes.CountAsync() == 0)
            {
                _context.ReportTypes.Add(new ReportType() { Name = "Month" });
                _context.ReportTypes.Add(new ReportType() { Name = "Quarter" });
                _context.ReportTypes.Add(new ReportType() { Name = "Year" });
                _context.ReportTypes.Add(new ReportType() { Name = "Custom" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
