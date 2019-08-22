using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
   public class PartServiceModel : BaseServiceModel, IMapFrom<Part>, IMapTo<Part>
    {

        public decimal Price { get; set; }

        public int UsedCount { get; set; }

        public string PartsProviderId { get; set; }
        public PartsProviderServiceModel AcquiredFrom { get; set; }

        public ICollection<InternalRepairPartServiceModel> InternalRepairParts { get; set; } = new HashSet<InternalRepairPartServiceModel>();

        public int Stock { get; set; }
    }
}
