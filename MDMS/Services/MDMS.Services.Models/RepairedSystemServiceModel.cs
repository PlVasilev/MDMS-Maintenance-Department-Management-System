using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
   public class RepairedSystemServiceModel
    {
        public string Id { get; set; }


        public string Name { get; set; }

        public ICollection<RepairServiceModel> Repairs { get; set; } = new HashSet<RepairServiceModel>();
    }
}
