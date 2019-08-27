using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Vehicle.Details
{
    public class VehicleDetailInternalRepairViewModel : IMapFrom<InternalRepairServiceModel>,IHaveCustomMappings
    {
        public string Name { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<InternalRepairServiceModel, VehicleDetailInternalRepairViewModel>()
                .ForMember(d => d.Name,
                    o => o.MapFrom(x => x.Name.Replace("_", " ")));
        }
    }
}
