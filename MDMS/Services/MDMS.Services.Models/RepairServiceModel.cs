using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDMS.Services.Models
{
   public class RepairServiceModel
    {
        public string Id { get; set; }

        public string Name => Vehicle.Make + " " + Vehicle.Model + " " + RepairedSystem.Name;

        public string Description { get; set; }

        public string VehicleId { get; set; }
        public VehicleServiceModel Vehicle { get; set; }

        public string RepairedSystemId { get; set; }
        public RepairServiceModel RepairedSystem { get; set; }

        public int Mileage { get; set; }

        public ICollection<MdmsUserRepairServiceModel> MdmsUserRepairs { get; set; } = new HashSet<MdmsUserRepairServiceModel>();


        public DateTime StartedOn { get; set; }

        public DateTime? FinishedOn { get; set; } = null;

        public ICollection<RepairPartServiceModel> RepairParts { get; set; } = new HashSet<RepairPartServiceModel>();

        public decimal RepairCost => RepairParts.Sum(x => x.Part.Price * x.Quantity) +
                                     MdmsUserRepairs.Sum(x =>
                                         x.MdmsUser.AdditionalOnHourPayment * (decimal)x.HoursWorked);
    }
}
