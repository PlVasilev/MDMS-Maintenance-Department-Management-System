using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Data.Models
{
   public class Part
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string PartsProviderId { get; set; }
        public PartsProvider AcquiredFrom { get; set; }

        ICollection<RepairPart> Repairs { get; set; } = new HashSet<RepairPart>();

        public int Stock { get; set; }
    }
}
