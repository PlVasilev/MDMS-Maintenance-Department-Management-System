using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Vehicle
{
    public class VehicleTypeCreateBindingModel : IMapTo<VehicleTypeServiceModel>
    {
        public string Name { get; set; }
    }
}
