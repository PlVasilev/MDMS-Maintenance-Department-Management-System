using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDMS.Data.Models
{
   public class Part
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "1000000")]
        public decimal Price { get; set; }

        [Required]
        public string PartsProviderId { get; set; }
        public PartsProvider AcquiredFrom { get; set; }

        ICollection<RepairPart> Repairs { get; set; } = new HashSet<RepairPart>();

        [Required]
        [Range(0, 100000)]
        public int Stock { get; set; }
    }
}
