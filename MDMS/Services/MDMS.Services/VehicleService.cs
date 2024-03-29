﻿using System.Linq;
using System.Threading.Tasks;
using MDMS.Data;
using MDMS.Data.Models;
using MDMS.Services.Mapping;
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
            if (_context.Vehicles.Any(v => v.VSN == vehicleServiceModel.VSN)) return false;
            
            Vehicle vehicle = AutoMapper.Mapper.Map<Vehicle>(vehicleServiceModel);
            vehicle.VehicleProvider = await GetVehicleProviderByName(vehicleServiceModel.VehicleProvider.Name);
            vehicle.VehicleType = await GetVehicleTypeByName(vehicleServiceModel.VehicleType.Name);

            _context.Vehicles.Add(vehicle);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteVehicle(string id)
        {
           var vehicle = _context.Vehicles.Find(id);
           vehicle.IsDeleted = true;
           _context.Vehicles.Update(vehicle);
           var result = await _context.SaveChangesAsync();
           return result > 0;
        }

        public async Task<bool> Edit(VehicleServiceModel vehicleServiceModel)
        {
            Vehicle vehicle = AutoMapper.Mapper.Map<Vehicle>(vehicleServiceModel);

            if (vehicle.IsDeleted) return false;
            
            vehicle.VehicleProvider = await GetVehicleProviderByName(vehicleServiceModel.VehicleProvider.Name);
            vehicle.VehicleType = await GetVehicleTypeByName(vehicleServiceModel.VehicleType.Name);

            _context.Vehicles.Update(vehicle);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        private async Task<VehicleType> GetVehicleTypeByName(string vehicleTypeName) => 
            await _context.VehicleTypes.SingleOrDefaultAsync(x => x.Name == vehicleTypeName);
        
        private async Task<VehicleProvider> GetVehicleProviderByName(string vehicleProviderName) => 
            await _context.VehicleProviders.SingleOrDefaultAsync(x => x.Name == vehicleProviderName);
        

        public async Task<bool> CreateVehicleType(VehicleTypeServiceModel vehicleTypeServiceModel)
        {
            if (_context.VehicleTypes.Any(v => v.Name == vehicleTypeServiceModel.Name))
                return false;
            
            VehicleType type = AutoMapper.Mapper.Map<VehicleType>(vehicleTypeServiceModel);
            _context.VehicleTypes.Add(type);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> CreateVehicleProvider(VehicleProviderServiceModel vehicleProviderServiceModel)
        {
            if (_context.VehicleProviders.Any(v => v.Name == vehicleProviderServiceModel.Name))
                return false;
            
            VehicleProvider provider = AutoMapper.Mapper.Map<VehicleProvider>(vehicleProviderServiceModel);
            _context.VehicleProviders.Add(provider);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public IQueryable<VehicleServiceModel> GetAllVehicles() => _context.Vehicles.Where(x => x.IsDeleted == false).To<VehicleServiceModel>();

        public IQueryable<VehicleTypeServiceModel> GetAllVehicleTypes() => _context.VehicleTypes.OrderBy(x => x.Name).To<VehicleTypeServiceModel>();

        public IQueryable<VehicleProviderServiceModel> GetAllVehicleProviders() => _context.VehicleProviders.OrderBy(x => x.Name).To<VehicleProviderServiceModel>();

        public async Task<VehicleServiceModel> GetVehicleByName(string name) => await Task.Run((() => _context.Vehicles
            .Include(x => x.VehicleProvider)
            .Include(x => x.InternalRepairs)
            .Include(x => x.ExternalRepairs)
            .Include(x => x.VehicleType)
            .To<VehicleServiceModel>().SingleOrDefaultAsync(x => x.Name == name && x.IsDeleted == false).Result));

    }
}
