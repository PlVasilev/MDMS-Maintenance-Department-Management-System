using System.Collections.Generic;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Report.Details
{
   public class ReportDetailsViewModel : IMapFrom<ReportServiceModel>,IHaveCustomMappings
    {
        public string Id { get; set; }
        public int StartMonth { get; set; }
        public int StartYear { get; set; }
        public int EndMonth { get; set; }
        public int EndYear { get; set; }
        public decimal ExternalRepairCosts { get; set; }
        public decimal InternalRepairCosts { get; set; }
        public decimal MechanicsBaseCosts { get; set; }
        public decimal VehicleBaseCost { get; set; }
        public int ReportDurationInMonths { get; set; } 
        public List<ReportMonthlySalariesDetailsViewModel> MonthlySalariesInReport { get ; set; } = new List<ReportMonthlySalariesDetailsViewModel>();
        public List<ReportVehicleDetailsViewModel> VehiclesInReport { get ; set; } = new List<ReportVehicleDetailsViewModel>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ReportServiceModel, ReportDetailsViewModel>()
                .ForMember(d => d.ReportDurationInMonths,
                    o => o.MapFrom(x => (x.EndYear - x.StartYear) * 12 + (x.EndMonth - x.StartMonth + 1)));

        }
    }
}
