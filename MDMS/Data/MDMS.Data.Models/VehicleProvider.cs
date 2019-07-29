using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDMS.Data.Models
{
    public class VehicleProvider : Base
    {
        public ICollection<Vehicle> VehiclesBought { get; set; } = new HashSet<Vehicle>();
    }
}
