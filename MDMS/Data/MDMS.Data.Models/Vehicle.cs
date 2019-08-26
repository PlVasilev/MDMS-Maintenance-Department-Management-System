using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;

namespace MDMS.Data.Models
{
    public class Vehicle : Base, IValidatableObject
    {
        [Required]
        [MaxLength(ModelConstants.NameLengthSm, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthStringSm)]
        public string Make { get; set; }

        [Required]
        [MaxLength(ModelConstants.NameLengthSm, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthStringSm)]
        public string Model { get; set; }

        [Required]
        [RegularExpression(ModelConstants.RegExVsn, ErrorMessage = ModelConstants.RegExVsnMessage)]
        public string VSN { get; set; }

        [Required]
        public string VehicleProviderId { get; set; }
        public VehicleProvider VehicleProvider { get; set; }

        [Range(ModelConstants.IntPositiveMin, ModelConstants.IntMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public int Mileage { get; set; }

        [RegularExpression(ModelConstants.RegExVehRegNumber, ErrorMessage = ModelConstants.RegExRegNumberMessage)]
        public string RegistrationNumber { get; set; }

        public bool IsInRepair { get; set; } = false;

        [Required]
        public DateTime AcquiredOn { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
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
                yield return new ValidationResult(ModelConstants.VehicleAcquiredAfterManufactured);
            }
        }
    }
}
