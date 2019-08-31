using System.Collections.Generic;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
   public class VehicleTypeServiceModel : BaseServiceModel, IMapFrom<VehicleType>, IMapTo<VehicleType>
    {
        public ICollection<VehicleServiceModel> Vehicles { get; set; } = new HashSet<VehicleServiceModel>();
    }
}
