using System;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
   public abstract class RepairServiceModel : BaseServiceModel, IMapFrom<Repair>, IMapTo<Repair>
    {
        public string Description { get; set; }

        public string VehicleId { get; set; }
        public VehicleServiceModel Vehicle { get; set; }

        public int Mileage { get; set; }

        public string RepairedSystemId { get; set; }
        public RepairedSystemServiceModel RepairedSystem { get; set; }

        public string MdmsUserId { get; set; }
        public MDMSUserServiceModel MdmsUser { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime? FinishedOn { get; set; } = null;

        public decimal RepairCost { get; set; }
    }
}
