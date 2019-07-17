using System.Threading.Tasks;
using MDMS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Data.Seeding
{
    public class RepairedSystemSeeder : ISeeder
    {
        private readonly MdmsDbContext _context;

        public RepairedSystemSeeder(MdmsDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.RepairedSystems.CountAsync() == 0)
            {
                _context.RepairedSystems.Add(new RepairedSystem() { Name = "Engine" });
                _context.RepairedSystems.Add(new RepairedSystem() { Name = "GearBox" });
                _context.RepairedSystems.Add(new RepairedSystem() { Name = "Electrical" });
                _context.RepairedSystems.Add(new RepairedSystem() { Name = "Hydraulic" });
                _context.RepairedSystems.Add(new RepairedSystem() { Name = "Fuel" });
                _context.RepairedSystems.Add(new RepairedSystem() { Name = "Chassis" });
                _context.RepairedSystems.Add(new RepairedSystem() { Name = "Breaking" });
                _context.RepairedSystems.Add(new RepairedSystem() { Name = "BodyWork" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
