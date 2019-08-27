using System;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Report.Details
{
   public class ReportVehicleDetailExternalRepairViewModel : IMapFrom<ExternalRepairServiceModel>, IHaveCustomMappings
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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ExternalRepairServiceModel, ReportVehicleDetailExternalRepairViewModel>()
                .ForMember(d => d.Name,
                    o => o.MapFrom(x => x.Name.Replace("_", " ")));
        }
    }
}
