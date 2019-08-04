using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
   public class ExternalRepairServiceModel : RepairServiceModel, IMapFrom<ExternalRepair>, IMapTo<ExternalRepair>
    {
        public ExternalRepairProviderServiceModel ExternalRepairProvider { get; set; }

        public decimal LaborCost { get; set; }

        public decimal PartsCost { get; set; }
    }
}
