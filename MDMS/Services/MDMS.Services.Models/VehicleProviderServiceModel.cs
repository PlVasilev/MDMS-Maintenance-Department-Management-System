using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
   public class VehicleProviderServiceModel : BaseServiceModel
    {
        public ICollection<VehicleServiceModel> Vehicles { get; set; } = new HashSet<VehicleServiceModel>();
    }
}
