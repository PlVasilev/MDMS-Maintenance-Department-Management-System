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
        [Range(1,12)]
        public int StartMonth { get; set; }

        [Required]
        [Range(1900, 2200)]
        public int StartYear { get; set; }

        [Required]
        [Range(1, 12)]
        public int EndMonth { get; set; }

        [Required]
        [Range(1900, 2200)]
        public int EndYear { get; set; }

        [Required]
        public string ReportTypeId { get; set; }
        public ReportType ReportType { get; set; }

        public ICollection<MonthlySalary> MonthlySalariesInReport { get; set; } = new HashSet<MonthlySalary>(); // => ExternalRepairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();
        public ICollection<Vehicle> VehiclesInReport { get; set; } = new HashSet<Vehicle>(); // => ExternalRepairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();

        [Range(0,int.MaxValue, ErrorMessage = "Must be positive Number")]
        public decimal ExternalRepairCosts { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be positive Number")]
        public decimal InternalRepairCosts { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be positive Number")]
        public decimal MechanicsBaseCosts { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be positive Number")]
        public decimal VehicleBaseCost { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndYear < StartYear)
            {
                yield return new ValidationResult("The End of the Report must be after The Start");
            }
            else if (EndYear == StartYear && EndMonth < StartMonth)
            {
                yield return new ValidationResult("The End of the Report must be after The Start");
            }
        }

    }
}
