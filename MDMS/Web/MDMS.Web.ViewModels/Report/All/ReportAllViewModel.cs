using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Report.All
{
    public class ReportAllViewModel : IMapFrom<ReportServiceModel>, IHaveCustomMappings
    {
        public string Name { get; set; }
        public int StartMonth { get; set; }
        public int StartYear { get; set; }
        public int EndMonth { get; set; }
        public int EndYear { get; set; }
        public string ReportTypeName { get; set; }
        public decimal ExternalRepairCosts { get; set; }
        public decimal InternalRepairCosts { get; set; }
        public decimal MechanicsBaseCosts { get; set; }
        public decimal VehicleBaseCost { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ReportServiceModel, ReportAllViewModel>()
                .ForMember(d => d.Name,
                    o => o.MapFrom(x => x.Name.Replace("_", " ")));
        }
    }
}
