using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Vehicle.Details
{
   public class VehicleDetailExternalRepairViewModel : IMapFrom<ExternalRepairServiceModel>, IHaveCustomMappings
    {
        public string Name { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ExternalRepairServiceModel, VehicleDetailExternalRepairViewModel>()
                .ForMember(d => d.Name,
                    o => o.MapFrom(x => x.Name.Replace("_", " ")));
        }
    }
}
