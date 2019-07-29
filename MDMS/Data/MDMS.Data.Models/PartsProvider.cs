using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDMS.Data.Models
{
   public class PartsProvider : Base
    {
        public ICollection<Part> PartsBought { get; set; } = new HashSet<Part>();
    }
}
