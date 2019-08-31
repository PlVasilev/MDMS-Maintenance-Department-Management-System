using System.Collections.Generic;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
   public class ExternalRepairProviderServiceModel : BaseServiceModel, IMapFrom<ExternalRepairProvider>, IMapTo<ExternalRepairProvider>
    {
        public ICollection<ExternalRepairServiceModel> ExternalRepairs { get; set; } = new HashSet<ExternalRepairServiceModel>();
    }
}
