using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Mdms.Data.Models;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace MDMS.Data.Models
{
   public abstract class Repair : Base
    {
        // Vehicle.Make + " " + Vehicle.Model + " " + RepairedSystem.Name + datetimeStart; NAME

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
        [DataType(DataType.DateTime)]
        public DateTime StartedOn { get; set; }

        public DateTime? FinishedOn { get; set; } = null;

        [Required]
        public MdmsUser MdmsUser { get; set; }

        [Range(typeof(decimal), "0.01", "9999999999", ErrorMessage = "Must be positive number")]
        public decimal RepairCost { get; set; } // Internal RepairParts.Sum(x => x.Part.Price * x.Quantity) +(MdmsUserRepair.MdmsUser.AdditionalOnHourPayment * (decimal)MdmsUserRepair.HoursWorked);
    }
}
