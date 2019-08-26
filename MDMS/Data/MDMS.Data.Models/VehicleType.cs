using System.Collections.Generic;

namespace MDMS.Data.Models
{
   public class VehicleType : Base
    {
        public ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
