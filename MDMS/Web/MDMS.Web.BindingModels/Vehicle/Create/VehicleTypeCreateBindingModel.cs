using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Vehicle.Create
{
    public class VehicleTypeCreateBindingModel : IMapTo<VehicleTypeServiceModel>
    {
        [Required]
        [MaxLength(ModelConstants.NameLength, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthString)]
        public string Name { get; set; }
    }
}
