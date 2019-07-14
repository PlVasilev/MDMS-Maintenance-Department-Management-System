using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDMS.Data.Models
{
   public class RepairPart
    {
        [Required]
        public string RepairId { get; set; }
        public Repair Repair { get; set; }

        [Required]
        public string PartId { get; set; }
        public Part Part { get; set; }

        [Range(1, 10000)]
        public int Quantity { get; set; }
    }
}
