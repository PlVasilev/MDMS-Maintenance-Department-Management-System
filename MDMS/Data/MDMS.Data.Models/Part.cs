using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDMS.Data.Models
{
   public class Part : Base
    {
        [Required]
        [Range(typeof(decimal), "0.00", "999999999")]
        public decimal Price { get; set; }

        [Required]
        public string PartsProviderId { get; set; }
        public PartsProvider AcquiredFrom { get; set; }

        public ICollection<InternalRepairPart> InternalRepairParts { get; set; } = new HashSet<InternalRepairPart>();

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
