using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Mdms.Data.Models;

namespace MDMS.Data.Models
{
   public class Report : Base , IValidatableObject
    {
        //Name : Type + start Month Year + End Month Year

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }

        [Required]
        public string ReportTypeId { get; set; }
        public ReportType ReportType { get; set; }

        public ICollection<InternalRepair> InternalRepairsInReport { get; set; } = new HashSet<InternalRepair>(); // => InternalRepairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();
        public ICollection<ExternalRepair> ExternalRepairsInReport { get; set; } = new HashSet<ExternalRepair>(); // => ExternalRepairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();
        public ICollection<MdmsUser> Users { get; set; } = new HashSet<MdmsUser>(); // => ExternalRepairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();
        public ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>(); // => ExternalRepairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();

        public decimal InternalRepairsConst => InternalRepairsInReport.Sum(z => z.InternalRepairParts.Sum(c => c.Part.Price * c.Quantity));
        public decimal ExternalRepairsConst => ExternalRepairsInReport.Sum(z => z.LaborCost + z.PartsCost);


        public decimal BaseCost => (Users.Sum(x => x.BaseSalary) + Vehicles.Sum(x => x.Depreciation)) *
                                   (End.Month - Start.Month - 1) + (12 * (End.Year - Start.Year - 1));

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.End >= this.Start)
            {
                yield return new ValidationResult("The End of the Report must be after The Start");
            }
        }

    }
}
