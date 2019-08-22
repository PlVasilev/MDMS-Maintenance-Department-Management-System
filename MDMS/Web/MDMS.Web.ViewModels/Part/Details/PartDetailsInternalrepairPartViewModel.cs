using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Part.Details
{
    public class PartDetailsInternalRepairPartViewModel : IMapFrom<InternalRepairPartServiceModel>
    {
        public string InternalRepairName { get; set; }
        public DateTime InternalRepairStartedOn { get; set; }
        public DateTime? InternalRepairFinishedOn { get; set; }
        public decimal InternalRepairRepairCost { get; set; }
        public int Quantity { get; set; }
    }
}
