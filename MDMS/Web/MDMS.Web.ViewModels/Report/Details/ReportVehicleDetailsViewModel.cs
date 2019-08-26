using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Report.Details
{
    public class ReportVehicleDetailsViewModel : IMapFrom<VehicleServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string VSN { get; set; }
        public string Picture { get; set; }
        public string VehicleProviderName { get; set; }
        public DateTime AcquiredOn { get; set; }
        public decimal Price { get; set; }
        public decimal Depreciation { get; set; }
        public DateTime ManufacturedOn { get; set; }
        public List<ReportVehicleDetailInternalRepairViewModel> InternalRepairs { get; set; } = new List<ReportVehicleDetailInternalRepairViewModel>();
        public decimal InternalRepairsTotalCost { get; set; }
        public decimal InternalRepairsLaborCost { get; set; }
        public decimal InternalRepairsPartsCost { get; set; }
        public List<ReportVehicleDetailExternalRepairViewModel> ExternalRepairs { get; set; } = new List<ReportVehicleDetailExternalRepairViewModel>();
        public decimal ExternalRepairsTotalCost { get; set; }
        public decimal ExternalRepairsLaborCost { get; set; }
        public decimal ExternalRepairsPartsCost { get; set; }
        public string VehicleTypeName { get; set; }
        public bool IsDeleted { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<VehicleServiceModel, ReportVehicleDetailsViewModel>()
                .ForMember(dest => dest.ExternalRepairsLaborCost,
                    opt => opt.MapFrom(org => org.ExternalRepairs.Sum(x => x.LaborCost)))
                .ForMember(dest => dest.ExternalRepairsPartsCost,
                    opt => opt.MapFrom(org => org.ExternalRepairs.Sum(x => x.PartsCost)))
                .ForMember(dest => dest.ExternalRepairsTotalCost,
                    opt => opt.MapFrom(org => org.ExternalRepairs.Sum(x => x.RepairCost)))
                .ForMember(dest => dest.InternalRepairsLaborCost,
                    opt => opt.MapFrom(org =>
                        org.InternalRepairs.Sum(x => (decimal)x.HoursWorked * x.MdmsUser.AdditionalOnHourPayment)))
                .ForMember(dest => dest.InternalRepairsPartsCost,
                    opt => opt.MapFrom(org =>
                        org.InternalRepairs.Sum(x => x.InternalRepairParts.Sum(y => y.Quantity * y.Part.Price))))
                .ForMember(dest => dest.InternalRepairsTotalCost,
                    opt => opt.MapFrom(org => org.InternalRepairs.Sum(x => x.RepairCost)));
        }
    }
}

