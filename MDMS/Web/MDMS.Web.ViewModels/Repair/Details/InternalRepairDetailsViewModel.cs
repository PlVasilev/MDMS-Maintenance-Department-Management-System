using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Repair.Details
{
    public class InternalRepairDetailsViewModel : IMapFrom<InternalRepairServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double HoursWorked { get; set; }

        public string VehicleName { get; set; }
        public string Description { get; set; }

        public string VehicleMake { get; set; }

        public string VehicleModel { get; set; }

        public string VehicleVSN { get; set; }

        public string RepairedSystemName { get; set; }

        public string MdmsUserUsername { get; set; }

        public int Mileage { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime? FinishedOn { get; set; } = null;

        public decimal RepairCost { get; set; }

        public List<InternalRepairDetailsRepairPartViewModel> InternalRepairParts { get; set; } = new List<InternalRepairDetailsRepairPartViewModel>();
    }
}
