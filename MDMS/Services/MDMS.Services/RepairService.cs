using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDMS.Data;
using MDMS.Data.Models;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Services
{
    public class RepairService : IRepairService
    {
        private readonly MdmsDbContext _context;

        public RepairService(MdmsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateExternalRepairProvider(ExternalRepairProviderServiceModel externalRepairProviderServiceModel)
        {
            if (_context.VehicleProviders.Any(v => v.Name == externalRepairProviderServiceModel.Name)) return false;

            _context.ExternalRepairProviders.Add(externalRepairProviderServiceModel.To<ExternalRepairProvider>());
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
