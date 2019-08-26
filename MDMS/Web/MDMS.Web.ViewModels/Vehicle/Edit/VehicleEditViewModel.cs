using System;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Vehicle.Edit
{
    public class VehicleEditViewModel : IMapFrom<VehicleServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string VSN { get; set; }
        public string VehicleProvider { get; set; }
        public DateTime AcquiredOn { get; set; }
        public decimal Price { get; set; }
        public decimal Depreciation { get; set; }
        public DateTime ManufacturedOn { get; set; }
        public string VehicleType { get; set; }
        public string Picture { get; set; }
        public decimal Mileage { get; set; }
        public string RegistrationNumber { get; set; }
        public bool IsInRepair { get; set; } = false;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<VehicleServiceModel, VehicleEditViewModel>()
                .ForMember(dest => dest.VehicleType,
                    opts => opts.MapFrom(org => org.VehicleType.Name))
                .ForMember(dest => dest.VehicleProvider,
                    opts => opts.MapFrom(org => org.VehicleProvider.Name));
        }
    }
}
