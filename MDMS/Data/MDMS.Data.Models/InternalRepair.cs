using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;

namespace MDMS.Data.Models
{
    public class InternalRepair : Repair
    {
        [Range(ModelConstants.DoublePositiveMin, ModelConstants.DoubleMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public double HoursWorked { get; set; }

        public ICollection<InternalRepairPart> InternalRepairParts { get; set; } = new HashSet<InternalRepairPart>();

    }
}
