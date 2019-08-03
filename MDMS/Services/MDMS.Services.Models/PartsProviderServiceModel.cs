using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
    public class PartsProviderServiceModel : BaseServiceModel, IMapFrom<PartsProvider>, IMapTo<PartsProvider>
    {
        public ICollection<PartServiceModel> PartsBought { get; set; } = new HashSet<PartServiceModel>();
    }
}
