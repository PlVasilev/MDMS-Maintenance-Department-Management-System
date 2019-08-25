using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Part.Details
{
    public class PartDetailsInternalRepairPartViewModel : IMapFrom<InternalRepairPartServiceModel>,IHaveCustomMappings
    {
        public string InternalRepairName { get; set; }
        public DateTime InternalRepairStartedOn { get; set; }
        public DateTime? InternalRepairFinishedOn { get; set; }
        public decimal InternalRepairRepairCost { get; set; }

        public decimal InternalRepairParsCost { get; set; }
        public int Quantity { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<InternalRepairPartServiceModel, PartDetailsInternalRepairPartViewModel>()
                .ForMember(dest => dest.InternalRepairParsCost,
                    opts => opts.MapFrom(org => org.Part.Price * org.Quantity));
        }
    }
}
