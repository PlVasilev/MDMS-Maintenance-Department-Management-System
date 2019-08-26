using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;

namespace MDMS.Data.Models
{
   public class Part : Base
    {
        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal Price { get; set; }

        [Required]
        public int UsedCount { get; set; }

        [Required]
        public string PartsProviderId { get; set; }
        public PartsProvider AcquiredFrom { get; set; }

        public ICollection<InternalRepairPart> InternalRepairParts { get; set; } = new HashSet<InternalRepairPart>();

        [Required]
        [Range(ModelConstants.IntPositiveMin, ModelConstants.IntMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public int Stock { get; set; }
    }
}
