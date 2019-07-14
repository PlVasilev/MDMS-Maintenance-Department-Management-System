using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDMS.Data.Models
{
    public class Vehicle
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        [RegularExpression("[A-Za-z0-9]{17}")]
        public string VSN { get; set; }

        [Required]
        public string VehicleProviderId { get; set; }
        public VehicleProvider AcquiredBy { get; set; }

        [Required]
        public DateTime AcquiredOn { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "100000")]
        public decimal Depreciation { get; set; }

        [Required]
        public DateTime ManufacturedOn { get; set; }

        public ICollection<Repair> Repairs { get; set; } = new HashSet<Repair>();

        public bool IsActive { get; set; } = false;
    }
}
