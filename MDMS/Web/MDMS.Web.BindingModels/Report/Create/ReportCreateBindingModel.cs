using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Report.Create
{
    public class ReportCreateBindingModel : IMapTo<ReportServiceModel> , IValidatableObject
    {
        [Required]
        [Range(ModelConstants.MonthMin, ModelConstants.MonthMax, ErrorMessage = ModelConstants.MonthRangeErrorMessage)]
        public int StartMonth { get; set; } = DateTime.UtcNow.Month;

        [Required]
        [Range(ModelConstants.YearMin, ModelConstants.YearMax, ErrorMessage = ModelConstants.YearRangeErrorMessage)]
        public int StartYear { get; set; } = DateTime.UtcNow.Year;

        [Required]
        [Range(ModelConstants.MonthMin, ModelConstants.MonthMax, ErrorMessage = ModelConstants.MonthRangeErrorMessage)]
        public int EndMonth { get; set; } = DateTime.UtcNow.Month;

        [Required]
        [Range(ModelConstants.YearMin, ModelConstants.YearMax, ErrorMessage = ModelConstants.YearRangeErrorMessage)]
        public int EndYear { get; set; } = DateTime.UtcNow.Year;

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
