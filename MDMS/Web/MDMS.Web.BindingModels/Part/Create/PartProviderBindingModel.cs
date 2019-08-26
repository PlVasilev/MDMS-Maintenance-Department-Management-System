using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Part.Create

{
    public class PartProviderBindingModel : IMapTo<PartsProviderServiceModel>
    {
        [Required]
        [MaxLength(ModelConstants.NameLength, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthString)]
        public string Name { get; set; }
    }
}
