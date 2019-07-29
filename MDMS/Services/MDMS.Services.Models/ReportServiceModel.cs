using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MDMS.Services.Models
{
   public class ReportServiceModel : BaseServiceModel
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string ReportTypeId { get; set; }
        public ReportTypeServiceModel ReportType { get; set; }

        private ICollection<RepairServiceModel> RepairsInReport { get; set; } // => Repairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();

        public decimal RepairsConst => RepairsInReport.Sum(z => z.RepairParts.Sum(c => c.Part.Price * c.Quantity));

        public ICollection<VehicleServiceModel> RepairedVehicles => RepairsInReport.Select(x => x.Vehicle).ToHashSet();

        public decimal BaseCost => (RepairsInReport.Sum(x => x.MdmsUser.BaseSalary) + RepairsInReport.Sum(x => x.Vehicle.Depreciation)) *
                                   (End.Month - Start.Month + 1) + (12 * (End.Year - Start.Year));

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.End >= this.Start)
            {
                yield return new ValidationResult("The End of the Report must be after The Start");
            }
        }

    }
}
