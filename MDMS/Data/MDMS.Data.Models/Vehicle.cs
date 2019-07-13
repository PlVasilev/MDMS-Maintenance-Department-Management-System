using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Data.Models
{
    public class Vehicle
    {
        public string Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string VSN { get; set; }

        public string VehicleProviderId { get; set; }
        public VehicleProvider AcquiredBy { get; set; }

        public DateTime AcquiredOn { get; set; }

        public decimal Depreciation { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public ICollection<Repair> Repairs { get; set; } = new HashSet<Repair>();

        public bool IsActive { get; set; }
    }
}
