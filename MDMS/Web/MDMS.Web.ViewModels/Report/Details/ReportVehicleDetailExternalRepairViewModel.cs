using System;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Report.Details
{
   public class ReportVehicleDetailExternalRepairViewModel : IMapFrom<ExternalRepairServiceModel>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RepairedSystemName { get; set; }
        public int Mileage { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime? FinishedOn { get; set; } 
        public string ExternalRepairProviderName { get; set; }
        public decimal LaborCost { get; set; }
        public decimal PartsCost { get; set; }
        public decimal RepairCost { get; set; }
    }
}
