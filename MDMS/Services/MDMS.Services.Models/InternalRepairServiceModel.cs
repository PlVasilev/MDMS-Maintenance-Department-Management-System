using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
    public class InternalRepairServiceModel : RepairServiceModel
    {
        public double HoursWorked { get; set; }

        public ICollection<InternalRepairPartServiceModel> InternalRepairParts { get; set; } = new HashSet<InternalRepairPartServiceModel>();
    }
}
