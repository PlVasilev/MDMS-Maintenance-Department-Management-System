using System.ComponentModel.DataAnnotations;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Vehicle.Create
{
    public class VehicleProviderCreateBindingModel : IMapTo<VehicleProviderServiceModel>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
