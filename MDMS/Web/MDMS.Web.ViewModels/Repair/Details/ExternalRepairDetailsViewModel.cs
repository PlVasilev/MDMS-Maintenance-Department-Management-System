using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Repair.Details
{
    public class ExternalRepairDetailsViewModel : IMapFrom<ExternalRepairServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string VehicleName { get; set; }

        public string VehicleMake { get; set; }

        public string VehicleModel { get; set; }

        public string VehicleVSN { get; set; }

        public string RepairedSystemName { get; set; }

        public string MdmsUserUsername { get; set; }

        public int Mileage { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime? FinishedOn { get; set; } = null;

        public string ExternalRepairProviderName { get; set; }

        public decimal LaborCost { get; set; }

        public decimal PartsCost { get; set; }

        public decimal RepairCost { get; set; }
    }
}
