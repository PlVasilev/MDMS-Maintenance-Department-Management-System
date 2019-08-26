using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
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
        [MaxLength(ModelConstants.NameLengthSm, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthStringSm)]
        public string Make { get; set; }

        [Required]
        [MaxLength(ModelConstants.NameLengthSm, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthStringSm)]
        public string Model { get; set; }

        [Required]
        [RegularExpression(ModelConstants.RegExVsn, ErrorMessage = ModelConstants.RegExVsnMessage)]
        public string VSN { get; set; }

        [Required]
        public string VehicleProvider { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AcquiredOn { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal Depreciation { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ManufacturedOn { get; set; }

        [Required]
        public string VehicleType { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        [Range(ModelConstants.IntPositiveMin, ModelConstants.IntMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public int Mileage { get; set; }

        [RegularExpression(ModelConstants.RegExVehRegNumber, ErrorMessage = ModelConstants.RegExRegNumberMessage)]
        public string RegistrationNumber { get; set; }

        public bool IsInRepair { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ManufacturedOn >= AcquiredOn)
            {
                yield return new ValidationResult(ModelConstants.VehicleAcquiredAfterManufactured);
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
