using System;
using System.Collections.Generic;

namespace MDMS.Services.Models
{
    public class VehicleServiceModel
    {
        public string Id { get; set; }


        public string Make { get; set; }

 
        public string Model { get; set; }


        public string VSN { get; set; }

        public string VehicleProviderId { get; set; }
        public VehicleProviderServiceModel AcquiredBy { get; set; }
        public DateTime AcquiredOn { get; set; }
        public decimal Price { get; set; }
        public decimal Depreciation { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public string Picture { get; set; }

        public ICollection<RepairServiceModel> Repairs { get; set; } = new HashSet<RepairServiceModel>();

        public VehicleTypeServiceModel VehicleType { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
