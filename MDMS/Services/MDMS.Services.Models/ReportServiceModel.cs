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

        public ICollection<InternalRepairServiceModel> InternalRepairsInReport { get; set; } = new HashSet<InternalRepairServiceModel>(); // => InternalRepairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();
        public ICollection<ExternalRepairServiceModel> ExternalRepairsInReport { get; set; } = new HashSet<ExternalRepairServiceModel>(); // => ExternalRepairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();
        public ICollection<MDMSUserServiceModel> Users { get; set; } = new HashSet<MDMSUserServiceModel>(); // => ExternalRepairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();
        public ICollection<VehicleServiceModel> Vehicles { get; set; } = new HashSet<VehicleServiceModel>(); // => ExternalRepairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();

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
