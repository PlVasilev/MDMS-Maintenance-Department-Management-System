using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;

namespace MDMS.Data.Models
{
   public class InternalRepairPart
    {
        [Required]
        public string InternalRepairId { get; set; }
        public InternalRepair InternalRepair { get; set; }

        [Required]
        public string PartId { get; set; }
        public Part Part { get; set; }

        [Range(ModelConstants.IntPositiveMinOne, ModelConstants.IntMax, ErrorMessage = ModelConstants.PositiveNumberFromOneErrorMessage)]
        public int Quantity { get; set; }
    }
}
