﻿using System.Linq;
using System.Threading.Tasks;
using MDMS.Services.Models;

namespace MDMS.Services
{
    public interface IVehicleService
    {
       Task<bool> Create(VehicleServiceModel vehicleServiceModel);
       Task<bool> DeleteVehicle(string id);
       Task<bool> Edit(VehicleServiceModel vehicleServiceModel);
       Task<bool> CreateVehicleType(VehicleTypeServiceModel vehicleTypeServiceModel);
       Task<bool> CreateVehicleProvider(VehicleProviderServiceModel vehicleProviderServiceModel);

       IQueryable<VehicleServiceModel> GetAllVehicles();
       IQueryable<VehicleTypeServiceModel> GetAllVehicleTypes();
       IQueryable<VehicleProviderServiceModel> GetAllVehicleProviders();
       Task<VehicleServiceModel> GetVehicleByName(string name);
    }
}
