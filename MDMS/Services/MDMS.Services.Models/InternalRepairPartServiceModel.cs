using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
   public class InternalRepairPartServiceModel
    {

        public string InternalRepairId { get; set; }
        public InternalRepairServiceModel InternalRepair { get; set; }

        public string PartId { get; set; }
        public PartServiceModel Part { get; set; }

        public int Quantity { get; set; }
    }
}
