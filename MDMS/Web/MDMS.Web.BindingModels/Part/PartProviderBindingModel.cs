using System.ComponentModel.DataAnnotations;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Part
{
    public class PartProviderBindingModel : IMapTo<PartsProviderServiceModel>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
