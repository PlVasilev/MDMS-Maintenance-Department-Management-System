using System.Threading.Tasks;
using MDMS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Data.Seeding
{
    public class VehicleTypeSeeder : ISeeder
    {
        private readonly MdmsDbContext _context;

        public VehicleTypeSeeder(MdmsDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.VehicleTypes.CountAsync() == 0)
            {
                _context.VehicleTypes.Add(new VehicleType() { Name = "Truck" });
                _context.VehicleTypes.Add(new VehicleType() { Name = "Loader" });
                _context.VehicleTypes.Add(new VehicleType() { Name = "Lift" });
                _context.VehicleTypes.Add(new VehicleType() { Name = "Trailer" });
                _context.VehicleTypes.Add(new VehicleType() { Name = "Car" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
