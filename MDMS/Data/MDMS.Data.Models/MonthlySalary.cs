using System.ComponentModel.DataAnnotations;
using Mdms.Data.Models;
using MDMS.GlobalConstants;

namespace MDMS.Data.Models
{
    public class MonthlySalary: Base
    {
        [Range(ModelConstants.MonthMin, ModelConstants.MonthMax, ErrorMessage = ModelConstants.MonthRangeErrorMessage)]
        public int Month { get; set; }

        [Range(ModelConstants.YearMin, ModelConstants.YearMax, ErrorMessage = ModelConstants.YearRangeErrorMessage)]
        public int Year { get; set; }

        [Required]
        public string MechanicId { get; set; }
        public MdmsUser Mechanic { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal AdditionalOnHourPayment { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal BaseSalary { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal TotalSalary { get; set; }

        [Range(ModelConstants.DoublePositiveMin, ModelConstants.DoubleMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public double HoursWorked { get; set; }
    }
}
