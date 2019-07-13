using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Data.Models
{
   public class PartsProvider
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Part> PartsBought { get; set; } = new HashSet<Part>();
    }
}
