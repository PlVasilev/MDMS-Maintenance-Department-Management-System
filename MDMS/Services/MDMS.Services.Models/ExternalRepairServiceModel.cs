using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
   public class ExternalRepairServiceModel : RepairServiceModel
    {
        public ExternalRepairProviderServiceModel ExternalRepairProvider { get; set; }

        public decimal LaborCost { get; set; }

        public decimal PartsCost { get; set; }
    }
}
