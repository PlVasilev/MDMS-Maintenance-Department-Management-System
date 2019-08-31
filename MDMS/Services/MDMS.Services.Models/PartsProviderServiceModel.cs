using System.Collections.Generic;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
    public class PartsProviderServiceModel : BaseServiceModel, IMapFrom<PartsProvider>, IMapTo<PartsProvider>
    {
        public ICollection<PartServiceModel> PartsBought { get; set; } = new HashSet<PartServiceModel>();
    }
}
