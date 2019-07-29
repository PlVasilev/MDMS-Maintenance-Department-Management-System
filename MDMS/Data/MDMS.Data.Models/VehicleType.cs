using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using System.Text;

namespace MDMS.Data.Models
{
   public class VehicleType : Base
    {
        public ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
