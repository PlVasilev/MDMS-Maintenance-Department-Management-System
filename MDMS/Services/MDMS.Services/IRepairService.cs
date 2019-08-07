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

        IQueryable<RepairedSystemServiceModel> GetAllRepairedSystems();
    }
}
