using System.Collections.Generic;

namespace MDMS.Data.Models
{
    public class VehicleProvider : Base
    {
        public ICollection<Vehicle> VehiclesBought { get; set; } = new HashSet<Vehicle>();
    }
}
