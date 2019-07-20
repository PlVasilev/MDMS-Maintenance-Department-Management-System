using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
    public class MdmsUserRepairServiceModel
    {
        public string MdmsUserId { get; set; }
        public MDMSUserServiceModel MdmsUser { get; set; }

        public string RepairId { get; set; }
        public RepairServiceModel Repair { get; set; }

        public double HoursWorked { get; set; }
    }
}
