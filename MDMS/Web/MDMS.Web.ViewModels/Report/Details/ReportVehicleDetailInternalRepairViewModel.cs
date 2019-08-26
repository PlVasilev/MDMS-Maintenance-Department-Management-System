using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Report.Details
{
   public class ReportVehicleDetailInternalRepairViewModel : IMapFrom<InternalRepairServiceModel>,IHaveCustomMappings
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string VehicleName { get; set; }
        public string RepairedSystemName { get; set; }
        public string MdmsUserUsername { get; set; }
        public int Mileage { get; set; }
        public decimal RepairCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal PartsCost { get; set; }
        public List<ReportInternalRepairDetailsRepairPartViewModel> InternalRepairParts { get; set; } = new List<ReportInternalRepairDetailsRepairPartViewModel>();


        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<InternalRepairServiceModel, ReportVehicleDetailInternalRepairViewModel>()
                .ForMember(dest => dest.LaborCost,
                    opt => opt.MapFrom(org => (decimal) org.HoursWorked * org.MdmsUser.AdditionalOnHourPayment))
                .ForMember(dest => dest.PartsCost,
                    opt => opt.MapFrom(org => org.InternalRepairParts.Sum(x => x.Quantity * x.Part.Price)));
        }
    }
}
