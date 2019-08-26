using System.Collections.Generic;

namespace MDMS.Data.Models
{
    public class ExternalRepairProvider : Base
    {
        ICollection<ExternalRepair> ExternalRepairs { get; set; } = new HashSet<ExternalRepair>();
    }
}
