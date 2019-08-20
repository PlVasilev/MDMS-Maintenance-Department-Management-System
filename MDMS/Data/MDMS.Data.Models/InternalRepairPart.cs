using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDMS.Data.Models
{
   public class InternalRepairPart
    {
        [Required]
        public string InternalRepairId { get; set; }
        public InternalRepair InternalRepair { get; set; }

        [Required]
        public string PartId { get; set; }
        public Part Part { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
