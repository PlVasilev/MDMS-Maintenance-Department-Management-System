using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDMS.Services.Models;

namespace MDMS.Services
{
    public interface IRepairService
    {
        Task<bool> CreateExternalRepairProvider(ExternalRepairProviderServiceModel externalRepairProviderServiceModel);

        Task<bool> CreateInternal(InternalRepairServiceModel internalRepairServiceModel);

        Task<bool> CreateExternal(ExternalRepairServiceModel externalRepairServiceModel);

        Task<InternalRepairServiceModel> GetActiveRepair(string id);

        IQueryable<RepairedSystemServiceModel> GetAllRepairedSystems();
        Task<IEnumerable<ExternalRepairServiceModel>>  GetAllExternalActiveRepairs();
        Task<IEnumerable<InternalRepairServiceModel>>  GetAllInternalActiveRepairs();
        IQueryable<ExternalRepairProviderServiceModel> GetAllExternalRepairProviders();
    }
}
