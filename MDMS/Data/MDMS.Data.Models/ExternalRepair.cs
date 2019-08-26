using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;

namespace MDMS.Data.Models
{
    public class ExternalRepair : Repair
    {
        [Required]
        public ExternalRepairProvider ExternalRepairProvider { get; set; }

        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal LaborCost { get; set; }

        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal PartsCost { get; set; }
    }
}
