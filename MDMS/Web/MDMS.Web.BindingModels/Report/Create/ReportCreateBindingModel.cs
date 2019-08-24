using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Report.Create
{
    public class ReportCreateBindingModel : IMapTo<ReportServiceModel> , IValidatableObject
    {
        [Required]
        [Range(1, 12, ErrorMessage = "Months Must be between 1 and 12")]
        public int StartMonth { get; set; } = DateTime.UtcNow.Month;

        [Required]
        [Range(1900, 2200, ErrorMessage = "Months Must be between 1900 and 2200")]
        public int StartYear { get; set; } = DateTime.UtcNow.Year;

        [Required]
        [Range(1, 12, ErrorMessage = "Months Must be between 1 and 12")]
        public int EndMonth { get; set; } = DateTime.UtcNow.Month;

        [Required]
        [Range(1900, 2200, ErrorMessage = "Months Must be between 1900 and 2200")]
        public int EndYear { get; set; } = DateTime.UtcNow.Year;

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
