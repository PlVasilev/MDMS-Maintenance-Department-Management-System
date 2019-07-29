﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
   public class PartServiceModel :BaseServiceModel
    {

        public decimal Price { get; set; }

        public string AcquiredFromId { get; set; }
        public PartsProviderServiceModel AcquiredFrom { get; set; }

        public ICollection<RepairPartServiceModel> RepairParts { get; set; } = new HashSet<RepairPartServiceModel>();

        public int Stock { get; set; }
    }
}
