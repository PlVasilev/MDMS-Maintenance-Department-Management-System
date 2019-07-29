using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Data.Models
{
    public class ExternalRepairProvider : Base
    {
        ICollection<ExternalRepairProvider> ExternalRepairProviders { get; set; } = new List<ExternalRepairProvider>();
    }
}
