using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services.Models;

namespace MDMS.Services
{
    public interface IRepairService
    {
        Task<bool> CreateExternalRepairProvider(ExternalRepairProviderServiceModel externalRepairProviderServiceModel);
        Task<bool> CreateInternal(InternalRepairServiceModel internalRepairServiceModel);
        Task<bool> CreateExternal(ExternalRepairServiceModel externalRepairServiceModel);
        Task<bool> EditExternalRepairDescription(string id,string description);
        Task<bool> EditInternalRepairDescription(string id, string description);
        Task<bool> FinalizeExternal(ExternalRepairServiceModel externalRepairServiceModel);
        Task<bool> FinalizeInternal(string id, double hours);
        Task<string> GetInternalRepairIdByName(string name);
        Task<InternalRepairServiceModel> GetInternalRepairByName(string name);
        Task<ExternalRepairServiceModel> GetExternalRepairByName(string name);
        Task<bool> AddPartsToInternalRepair(List<InternalRepairPartServiceModel> internalRepairPartServiceModels);

        Task<ExternalRepairServiceModel> GetExternalActiveRepair(string name);
        Task<InternalRepairServiceModel> GetActiveRepair(string id);

        Task<IEnumerable<ExternalRepairServiceModel>>  GetAllExternalActiveRepairs();
        Task<IEnumerable<InternalRepairServiceModel>>  GetAllInternalActiveRepairs();

        IQueryable<RepairedSystemServiceModel> GetAllRepairedSystems();
        IQueryable<ExternalRepairProviderServiceModel> GetAllExternalRepairProviders();
        IQueryable<ExternalRepairServiceModel> GetAllExternalRepairs();
        IQueryable<InternalRepairServiceModel> GetAllInternalRepairs();
        IQueryable<ExternalRepairServiceModel> GetActiveRepairs(string id);
    }
}
