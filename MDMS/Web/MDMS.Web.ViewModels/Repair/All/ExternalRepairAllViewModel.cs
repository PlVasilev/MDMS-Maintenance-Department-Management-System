using System;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Repair.All
{
    public class ExternalRepairAllViewModel : IMapFrom<ExternalRepairServiceModel>
    {
        public string Name { get; set; }

        public string RepairCost { get; set; }

        public DateTime StartedOn { get; set; }
        public DateTime? FinishedOn { get; set; }
        public string MdmsUserUserName { get; set; }
    }
}
