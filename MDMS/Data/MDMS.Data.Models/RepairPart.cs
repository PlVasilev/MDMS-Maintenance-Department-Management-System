using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Data.Models
{
   public class RepairPart
    {
        public string RepairId { get; set; }
        public Repair Repair { get; set; }

        public string PartId { get; set; }
        public Part Part { get; set; }

        public int Quantity { get; set; }
    }
}
