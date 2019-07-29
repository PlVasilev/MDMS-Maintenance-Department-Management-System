using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDMS.Data.Models
{
    public class ExternalRepair : Repair
    {
        [Required]
        public ExternalRepairProvider ExternalRepairProvider { get; set; }

        [Range(typeof(decimal), "0.01", "9999999999", ErrorMessage = "Must be positive number")]
        public decimal LaborCost { get; set; }

        [Range(typeof(decimal), "0.01", "9999999999", ErrorMessage = "Must be positive number")]
        public decimal PartsCost { get; set; }
    }
}
