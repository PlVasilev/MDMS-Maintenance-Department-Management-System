using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace MDMS.Data.Models
{
    public class Vehicle : Base, IValidatableObject
    {
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        [MaxLength(17)]
        public string VSN { get; set; }

        [Required]
        public string VehicleProviderId { get; set; }
        public VehicleProvider VehicleProvider { get; set; }

        [Required]
        public DateTime AcquiredOn { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "999999999")]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "999999999")]
        public decimal Depreciation { get; set; }

        [Required]
        public DateTime ManufacturedOn { get; set; }

        [Required]
        public string Picture { get; set; }

        public ICollection<InternalRepair> InternalRepairs { get; set; } = new HashSet<InternalRepair>();
        public ICollection<ExternalRepair> ExternalRepairs { get; set; } = new HashSet<ExternalRepair>();

        public VehicleType VehicleType { get; set; }

        public bool IsActive { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ManufacturedOn >= AcquiredOn)
            {
                yield return new ValidationResult("The Vehicle Acquired must be after Manufactured!");
            }
        }
    }
}
