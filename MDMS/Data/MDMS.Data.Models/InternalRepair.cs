using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Mdms.Data.Models;

namespace MDMS.Data.Models
{
    public class InternalRepair : Repair
    {
        [Range(0, int.MaxValue)]
        public double HoursWorked { get; set; }

        public ICollection<InternalRepairPart> InternalRepairParts { get; set; } = new HashSet<InternalRepairPart>();

        

    }
}
