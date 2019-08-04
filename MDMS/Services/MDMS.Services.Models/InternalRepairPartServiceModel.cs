using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
   public class InternalRepairPartServiceModel : IMapFrom<InternalRepairPart>, IMapTo<InternalRepairPart>
    {

        public string InternalRepairId { get; set; }
        public InternalRepairServiceModel InternalRepair { get; set; }

        public string PartId { get; set; }
        public PartServiceModel Part { get; set; }

        public int Quantity { get; set; }
    }
}
