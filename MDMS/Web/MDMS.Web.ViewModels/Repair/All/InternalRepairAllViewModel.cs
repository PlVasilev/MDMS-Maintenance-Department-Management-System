using System;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Repair.All
{
    public class InternalRepairAllViewModel : IMapFrom<InternalRepairServiceModel> ,IHaveCustomMappings
    {
        public string Name { get; set; }
        public string RepairCost { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime? FinishedOn { get; set; }

        public string MdmsUserUserName { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<InternalRepairServiceModel, InternalRepairAllViewModel>()
                .ForMember(d => d.Name,
                    o => o.MapFrom(x => x.Name.Replace("_", " ")));
        }
    }
}
