using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;

namespace MDMS.Data.Models
{
   public class Report : Base , IValidatableObject
    {
        
        [Required]
        [Range(ModelConstants.MonthMin, ModelConstants.MonthMax, ErrorMessage = ModelConstants.MonthRangeErrorMessage)]
        public int StartMonth { get; set; }

        [Required]
        [Range(ModelConstants.YearMin, ModelConstants.YearMax, ErrorMessage = ModelConstants.YearRangeErrorMessage)]
        public int StartYear { get; set; }

        [Required]
        [Range(ModelConstants.MonthMin, ModelConstants.MonthMax, ErrorMessage = ModelConstants.MonthRangeErrorMessage)]
        public int EndMonth { get; set; }

        [Required]
        [Range(ModelConstants.YearMin, ModelConstants.YearMax, ErrorMessage = ModelConstants.YearRangeErrorMessage)]
        public int EndYear { get; set; }

        [Required]
        public string ReportTypeId { get; set; }
        public ReportType ReportType { get; set; }

        public ICollection<MonthlySalary> MonthlySalariesInReport { get; set; } = new HashSet<MonthlySalary>(); 
        public ICollection<Vehicle> VehiclesInReport { get; set; } = new HashSet<Vehicle>(); 

        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal ExternalRepairCosts { get; set; }

        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal InternalRepairCosts { get; set; }

        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal MechanicsBaseCosts { get; set; }

        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal VehicleBaseCost { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndYear < StartYear)
            {
                yield return new ValidationResult(ModelConstants.EndOfReportBeforeStart);
            }
            else if (EndYear == StartYear && EndMonth < StartMonth)
            {
                yield return new ValidationResult(ModelConstants.EndOfReportBeforeStart);
            }
        }

    }
}
