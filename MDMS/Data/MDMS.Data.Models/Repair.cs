using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace MDMS.Data.Models
{
   public class Repair
    {
        public string Id { get; set; }

        public string Name => Vehicle.Make + " " + Vehicle.Model + " " + RepairedSystem.Name;

        public string Description { get; set; }

        public string VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public string RepairedSystemId { get; set; }
        public RepairedSystem RepairedSystem { get; set; }

        public int Mileage { get; set; }

        public ICollection<MdmsUserRepair> MdmsUserRepairs { get; set; } = new HashSet<MdmsUserRepair>();

        public DateTime StartedOn { get; set; }

        public DateTime FinishedOn { get; set; }

        public ICollection<RepairPart> RepairParts { get; set; } = new HashSet<RepairPart>();

        public decimal RepairCost => RepairParts.Sum(x => x.Part.Price * x.Quantity) +
                                     MdmsUserRepairs.Sum(x =>
                                         x.MdmsUser.AdditionalOnHourPayment * (decimal) x.HoursWorked);
    }
}
