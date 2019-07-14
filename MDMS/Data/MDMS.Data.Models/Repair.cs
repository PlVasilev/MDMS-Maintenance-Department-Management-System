using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace MDMS.Data.Models
{
   public class Repair
    {
        public string Id { get; set; }

        public string Name => Vehicle.Make + " " + Vehicle.Model + " " + RepairedSystem.Name;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        [Required]
        public string RepairedSystemId { get; set; }
        public RepairedSystem RepairedSystem { get; set; }

        [Required]
        [Range(0,10000000)]
        public int Mileage { get; set; }

        public ICollection<MdmsUserRepair> MdmsUserRepairs { get; set; } = new HashSet<MdmsUserRepair>();

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartedOn { get; set; }

        public DateTime? FinishedOn { get; set; } = null;

        public ICollection<RepairPart> RepairParts { get; set; } = new HashSet<RepairPart>();

        public decimal RepairCost => RepairParts.Sum(x => x.Part.Price * x.Quantity) +
                                     MdmsUserRepairs.Sum(x =>
                                         x.MdmsUser.AdditionalOnHourPayment * (decimal) x.HoursWorked);
    }
}
