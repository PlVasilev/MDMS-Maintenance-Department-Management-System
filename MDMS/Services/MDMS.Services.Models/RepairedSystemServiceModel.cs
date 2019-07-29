using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
   public class RepairedSystemServiceModel : BaseServiceModel
    {
        public ICollection<RepairServiceModel> Repairs { get; set; } = new HashSet<RepairServiceModel>();
    }
}
