using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Part.Create
{
    public class PartCreateBindingModel : IMapTo<PartServiceModel>, IHaveCustomMappings
    {
        [Required]
        [MaxLength(ModelConstants.NameLength, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthString)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal Price { get; set; }

        [Required]
        [Range(ModelConstants.IntPositiveMin, ModelConstants.IntMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public int Stock { get; set; }

        [Required]
        public string AcquiredFrom { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<PartCreateBindingModel, PartServiceModel>()
                .ForMember(dest => dest.AcquiredFrom,
                    opts => opts.MapFrom(org => new PartsProviderServiceModel() {Name = org.AcquiredFrom}));
        }
    } 
}
