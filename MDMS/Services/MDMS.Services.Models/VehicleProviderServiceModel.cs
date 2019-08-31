using System.Collections.Generic;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
   public class VehicleProviderServiceModel : BaseServiceModel, IMapFrom<VehicleProvider>, IMapTo<VehicleProvider>
    {
        public ICollection<VehicleServiceModel> Vehicles { get; set; } = new HashSet<VehicleServiceModel>();
    }
}
