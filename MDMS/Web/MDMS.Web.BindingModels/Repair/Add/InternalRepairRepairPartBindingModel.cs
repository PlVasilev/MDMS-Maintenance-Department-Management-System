using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace MDMS.Web.BindingModels.Repair.Add
{
   public  class InternalRepairRepairPartBindingModel : IMapFrom<PartServiceModel>, IMapTo<InternalRepairPartServiceModel>, IHaveCustomMappings, IValidatableObject
    {
        public string RepairName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "999999999")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be positive Number")]
        public int UsedCount { get; set; }

        public string AcquiredFromName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be positive Number")]
        public int Stock { get; set; }

        public string InternalRepairId { get; set; }

        public string PartId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be positive Number")]
        public int Quantity { get; set; }


        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<PartServiceModel, InternalRepairRepairPartBindingModel>()
                .ForMember(dest => dest.PartId, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.AcquiredFromName, opts => opts.MapFrom(x => x.AcquiredFrom.Name));
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Quantity > Stock)
            {
                yield return new ValidationResult($"You Can not add more {Name} than its stock");
            }
        }
    }
}
