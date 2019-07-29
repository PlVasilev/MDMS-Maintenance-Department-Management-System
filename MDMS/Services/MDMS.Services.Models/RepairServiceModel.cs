using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDMS.Services.Models
{
   public class RepairServiceModel : BaseServiceModel
    {
        public string Description { get; set; }

        public string VehicleId { get; set; }
        public VehicleServiceModel Vehicle { get; set; }

        public string RepairedSystemId { get; set; }
        public RepairServiceModel RepairedSystem { get; set; }

        public MDMSUserServiceModel MdmsUser { get; set; }

        public double HoursWorked { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime? FinishedOn { get; set; } = null;

        public ICollection<RepairPartServiceModel> RepairParts { get; set; } = new HashSet<RepairPartServiceModel>();

        public decimal RepairCost { get; set; }
    }
}
