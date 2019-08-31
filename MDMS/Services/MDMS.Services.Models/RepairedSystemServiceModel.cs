using System.Collections.Generic;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
   public class RepairedSystemServiceModel : BaseServiceModel, IMapFrom<RepairedSystem>, IMapTo<RepairedSystem>
    {
        public ICollection<RepairServiceModel> Repairs { get; set; } = new HashSet<RepairServiceModel>();
    }
}
