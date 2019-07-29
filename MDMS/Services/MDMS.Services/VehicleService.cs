using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MDMS.Data;
using MDMS.Data.Models;
using MDMS.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly MdmsDbContext _context;

        public VehicleService(MdmsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(VehicleServiceModel vehicleServiceModel)
        {
            if (_context.Vehicles.Any(v => v.VSN == vehicleServiceModel.VSN))
            {
                return false;
            }

            Vehicle vehicle = new Vehicle()
           {
               Make = vehicleServiceModel.Make,
               Model = vehicleServiceModel.Model,
               VSN = vehicleServiceModel.VSN,
               AcquiredOn = vehicleServiceModel.AcquiredOn,
               Depreciation = vehicleServiceModel.Depreciation,
               ManufacturedOn = vehicleServiceModel.ManufacturedOn,
               VehicleProvider = await GetVehicleProviderByName(vehicleServiceModel.VehicleProvider.Name),
               VehicleType = await GetVehicleTypeByName(vehicleServiceModel.VehicleType.Name),
               Price = vehicleServiceModel.Price,
               Picture = vehicleServiceModel.Picture
           };

        
           _context.Vehicles.Add(vehicle);
           var result = await _context.SaveChangesAsync();

           return result > 0;
        }



        private async Task<VehicleType> GetVehicleTypeByName(string vehicleTypeName)
        {
            return await _context.VehicleTypes.SingleOrDefaultAsync(x => x.Name == vehicleTypeName);
        }

        private async Task<VehicleProvider> GetVehicleProviderByName(string vehicleProviderName)
        {
            return await _context.VehicleProviders.SingleOrDefaultAsync(x => x.Name == vehicleProviderName);
        }

        public async Task<bool> CreateVehicleType(VehicleTypeServiceModel vehicleTypeServiceModel)
        {
            VehicleType type = new VehicleType()
            {
                Name = vehicleTypeServiceModel.Name
            };

            _context.VehicleTypes.Add(type);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> CreateVehicleProvider(VehicleProviderServiceModel vehicleProviderServiceModel)
        {
            VehicleProvider provider = new VehicleProvider()
            {
                Name = vehicleProviderServiceModel.Name
            };

            _context.VehicleProviders.Add(provider);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<VehicleServiceModel> GetAllVehicles()
        {
            return _context.Vehicles.Select(v => new VehicleServiceModel()
            {
                Id = v.Id,
                Make = v.Make,
                Model = v.Model,
                VSN = v.VSN,
                Picture = v.Picture
            });
        } 


        public IQueryable<VehicleTypeServiceModel> GetAllVehicleTypes()
        {
            return _context.VehicleTypes.Select(vt => new VehicleTypeServiceModel
            {
                Id = vt.Id,
                Name = vt.Name
            });
        }

        public IQueryable<VehicleProviderServiceModel> GetAllVehicleProviders()
        {
            return _context.VehicleProviders.Select(vt => new VehicleProviderServiceModel
            {
                Id = vt.Id,
                Name = vt.Name
            });
        }
    }
}
