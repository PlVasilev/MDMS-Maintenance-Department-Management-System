using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
   public class RepairPartServiceModel
    {

        public string RepairId { get; set; }
        public RepairServiceModel Repair { get; set; }

        public string PartId { get; set; }
        public PartServiceModel Part { get; set; }

        public int Quantity { get; set; }
    }
}
