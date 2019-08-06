using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Data.Models
{
    public class ExternalRepairProvider : Base
    {
        ICollection<ExternalRepair> ExternalRepairs { get; set; } = new HashSet<ExternalRepair>();
    }
}
