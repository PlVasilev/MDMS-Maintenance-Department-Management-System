using System.Collections.Generic;

namespace MDMS.Data.Models
{
    public class RepairedSystem : Base
    {
        public ICollection<InternalRepair> InternalRepairs { get; set; }  = new HashSet<InternalRepair>();
        public ICollection<ExternalRepair> ExternalRepairs { get; set; }  = new HashSet<ExternalRepair>();
    }
}
