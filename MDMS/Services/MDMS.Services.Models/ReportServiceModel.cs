using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MDMS.Services.Models
{
   public class ReportServiceModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string ReportTypeId { get; set; }
        public ReportTypeServiceModel ReportType { get; set; }

        public ICollection<RepairServiceModel> Repairs { get; set; } = new HashSet<RepairServiceModel>();

        public ICollection<MDMSUserServiceModel> Users { get; set; } = new HashSet<MDMSUserServiceModel>();

        public ICollection<VehicleServiceModel> Vehicles { get; set; } = new HashSet<VehicleServiceModel>();

        private ICollection<RepairServiceModel> RepairsInReport => Repairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();

        public decimal RepairsConst => RepairsInReport.Sum(z => z.RepairParts.Sum(c => c.Part.Price * c.Quantity));

        public ICollection<VehicleServiceModel> RepairedVehicles => RepairsInReport.Select(x => x.Vehicle).ToHashSet();

        public decimal BaseCost => (Users.Sum(x => x.BaseSalary) + Vehicles.Sum(x => x.Depreciation)) *
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
