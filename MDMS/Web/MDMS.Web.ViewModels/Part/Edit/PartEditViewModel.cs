using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Part.Edit
{
    public class PartEditViewModel : IMapFrom<PartServiceModel>,IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.NameLength, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthString)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal Price { get; set; }

        public int UsedCount { get; set; }


        [Required]
        public string AcquiredFrom { get; set; }

        public int Stock { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<PartServiceModel, PartEditViewModel>()
                .ForMember(dest => dest.AcquiredFrom,
                    opts => opts.MapFrom(org => org.AcquiredFrom.Name));

        }
    }
}
