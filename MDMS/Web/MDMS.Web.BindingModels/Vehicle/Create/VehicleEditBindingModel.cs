using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using Microsoft.AspNetCore.Http;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace MDMS.Web.BindingModels.Vehicle.Create
{
    public class VehicleEditBindingModel : IValidatableObject, IMapTo<VehicleServiceModel>, IHaveCustomMappings
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Make must be less or equal to 50 symbols")]
        public string Make { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Model must be less or equal to 50 symbols")]
        public string Model { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z0-9]{17}$", ErrorMessage = "VSN Must be 17 symbols English letters and digits Only !")]
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
        [Range(typeof(decimal), "0.01", "9999999999", ErrorMessage = "Must be positive number")]
        public decimal Depreciation { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ManufacturedOn { get; set; }

        [Required]
        public string VehicleType { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "9999999999", ErrorMessage = "Must be positive number")]
        public decimal Mileage { get; set; }

        [RegularExpression("^[A-Za-z0-9]{3,9}$", ErrorMessage = "Registration Number must be between 3 and 9 characters included.")]
        public string RegistrationNumber { get; set; }

        public bool IsInRepair { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ManufacturedOn >= AcquiredOn)
            {
                yield return new ValidationResult("The Vehicle Acquired must be after Manufactured!");
            }
        }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<VehicleEditBindingModel, VehicleServiceModel>()
                .ForMember(dest => dest.VehicleType,
                    opts => opts.MapFrom(org => new VehicleTypeServiceModel() { Name = org.VehicleType }))
                .ForMember(dest => dest.VehicleProvider,
                    opts => opts.MapFrom(org => new VehicleProviderServiceModel() { Name = org.VehicleProvider }))
                .ForMember(dest => dest.RegistrationNumber,
                opts => opts.MapFrom(org => org.RegistrationNumber.ToUpper()));
        }
    }
}
