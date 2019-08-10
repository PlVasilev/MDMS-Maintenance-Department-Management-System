﻿using System;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Data;
using MDMS.Data.Models;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> CreateInternal(InternalRepairServiceModel internalRepairServiceModel)
        {
            internalRepairServiceModel.StartedOn = DateTime.UtcNow;
            internalRepairServiceModel.Name = internalRepairServiceModel.Name + "_" +
                                              internalRepairServiceModel.StartedOn.ToString("yyyy/MM/dd_HH:mm");

            if (_context.InternalRepairs.Any(x => x.Name == internalRepairServiceModel.Name)) return false;
            

            var internalRepair = internalRepairServiceModel.To<InternalRepair>();
            internalRepair.RepairedSystem = await GetRepairedSystemIdByName(internalRepairServiceModel.RepairedSystem.Name);
            _context.InternalRepairs.Add(internalRepair);

            var vehicle = _context.Vehicles.Find(internalRepairServiceModel.VehicleId);
            vehicle.Mileage = internalRepair.Mileage;
            vehicle.IsInRepair = true;
            vehicle.InternalRepairs.Add(internalRepair);
            _context.Update(vehicle);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> CreateExternal(ExternalRepairServiceModel externalRepairServiceModel)
        {
            externalRepairServiceModel.StartedOn = DateTime.UtcNow;
            externalRepairServiceModel.Name = externalRepairServiceModel.Name + "_" +
                                              externalRepairServiceModel.StartedOn.ToString("yyyy/MM/dd_HH:mm");

            if (_context.InternalRepairs.Any(x => x.Name == externalRepairServiceModel.Name)) return false;


            var externalRepair = externalRepairServiceModel.To<ExternalRepair>();
            externalRepair.RepairedSystem = await GetRepairedSystemIdByName(externalRepairServiceModel.RepairedSystem.Name);
            externalRepair.ExternalRepairProvider = await GetExternalRepairProviderByName(externalRepairServiceModel.ExternalRepairProvider.Name);
            _context.ExternalRepairs.Add(externalRepair);

            var vehicle = _context.Vehicles.Find(externalRepairServiceModel.VehicleId);
            vehicle.Mileage = externalRepair.Mileage;
            vehicle.IsInRepair = true;
            vehicle.ExternalRepairs.Add(externalRepair);
            _context.Update(vehicle);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<RepairedSystemServiceModel> GetAllRepairedSystems() => _context.RepairedSystems.To<RepairedSystemServiceModel>();

        public IQueryable<ExternalRepairProviderServiceModel> GetAllExternalRepairProviders() => _context.ExternalRepairProviders.To<ExternalRepairProviderServiceModel>();
    

        private async Task<RepairedSystem> GetRepairedSystemIdByName(string repairedSystemName) =>
            await _context.RepairedSystems.SingleOrDefaultAsync(x => x.Name == repairedSystemName);

        private async Task<ExternalRepairProvider> GetExternalRepairProviderByName(string name) => 
            await _context.ExternalRepairProviders.SingleOrDefaultAsync(x => x.Name == name);

    }
}
