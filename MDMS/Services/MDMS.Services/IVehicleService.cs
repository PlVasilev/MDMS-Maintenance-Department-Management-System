using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services.Models;

namespace MDMS.Services
{
    public interface IVehicleService
    {
       Task<bool> Create(VehicleServiceModel vehicleServiceModel);
       Task<bool> CreateVehicleType(VehicleTypeServiceModel vehicleTypeServiceModel);
       Task<bool> CreateVehicleProvider(VehicleProviderServiceModel vehicleProviderServiceModel);


       Task<IQueryable<VehicleServiceModel>> GetAllVehicles();
        Task<IQueryable<VehicleTypeServiceModel>> GetAllVehicleTypes();
       Task<IQueryable<VehicleProviderServiceModel>> GetAllVehicleProviders();
    }
}
