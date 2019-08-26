using System.Collections.Generic;

namespace MDMS.Data.Models
{
   public class PartsProvider : Base
    {
        public ICollection<Part> PartsBought { get; set; } = new HashSet<Part>();
    }
}
