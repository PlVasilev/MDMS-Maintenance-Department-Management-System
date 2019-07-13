using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Data.Models
{
    public class VehicleProvider
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Vehicle> VehiclesBought { get; set; } = new HashSet<Vehicle>();
    }
}
