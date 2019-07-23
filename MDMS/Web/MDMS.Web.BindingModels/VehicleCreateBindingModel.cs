using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MDMS.Web.BindingModels
{
   public class VehicleCreateBindingModel : IValidatableObject
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Make must be less or equal to 50 symbols")]
        public string Make { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Model must be less or equal to 50 symbols")]
        public string Model { get; set; }

        [Required]
        [RegularExpression("[A-Za-z0-9]{17}", ErrorMessage = "VSN Must be 17 symbols English letters and digits Only !")]
        public string VSN { get; set; }

        [Required]
        public string VehicleProvider { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AcquiredOn { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "9999999999", ErrorMessage = "Must be positive number")]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "9999999999",ErrorMessage = "Must be positive number")]
        public decimal Depreciation { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ManufacturedOn { get; set; }

        [Required]
        public string VehicleType { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ManufacturedOn >= AcquiredOn)
            {
                yield return new ValidationResult("The Vehicle Acquired must be after Manufactured!");
            }
        }
    }
}
