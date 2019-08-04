using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
    public class InternalRepairServiceModel : RepairServiceModel, IMapFrom<InternalRepair>, IMapTo<InternalRepair>
    {
        public double HoursWorked { get; set; }

        public ICollection<InternalRepairPartServiceModel> InternalRepairParts { get; set; } = new HashSet<InternalRepairPartServiceModel>();
    }
}
