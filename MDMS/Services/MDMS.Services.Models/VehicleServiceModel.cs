using System;
using System.Collections.Generic;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
    public class VehicleServiceModel : BaseServiceModel, IMapFrom<Vehicle>, IMapTo<Vehicle>
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string VSN { get; set; }

        public string VehicleProviderId { get; set; }

        public VehicleProviderServiceModel VehicleProvider { get; set; }

        public DateTime AcquiredOn { get; set; }

        public decimal Price { get; set; }

        public decimal Depreciation { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public string Picture { get; set; }

        public ICollection<InternalRepairServiceModel> InternalRepairs { get; set; } = new HashSet<InternalRepairServiceModel>();
        public ICollection<ExternalRepairServiceModel> ExternalRepairs { get; set; } = new HashSet<ExternalRepairServiceModel>();

        public VehicleTypeServiceModel VehicleType { get; set; }

        public bool IsActive { get; set; } = false;

        public int Mileage { get; set; }

        public string RegistrationNumber { get; set; }

        public bool IsInRepair { get; set; } = false;
    }
}
