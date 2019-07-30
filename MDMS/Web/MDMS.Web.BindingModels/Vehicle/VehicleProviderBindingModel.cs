using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Vehicle
{
    public class VehicleProviderBindingModel : IMapTo<VehicleProviderServiceModel>
    {
        public string Name { get; set; }
    }
}
