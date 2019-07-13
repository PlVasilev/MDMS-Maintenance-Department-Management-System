﻿using System;
using System.Collections.Generic;
using System.Text;
using Mdms.Data.Models;

namespace MDMS.Data.Models
{
   public class MdmsUserRepair
    {
        public string MdmsUserId { get; set; }
        public MdmsUser MdmsUser { get; set; }

        public string RepairId { get; set; }
        public Repair Repair { get; set; }

        public double HoursWorked { get; set; }
    }
}
