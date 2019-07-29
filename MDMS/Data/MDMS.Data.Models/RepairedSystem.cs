using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDMS.Data.Models
{
    public class RepairedSystem : Base
    {
        public ICollection<InternalRepair> InternalRepairs { get; set; }  = new HashSet<InternalRepair>();
        public ICollection<ExternalRepair> ExternalRepairs { get; set; }  = new HashSet<ExternalRepair>();
    }
}
