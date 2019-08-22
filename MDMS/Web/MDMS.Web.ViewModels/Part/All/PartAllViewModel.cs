using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Part.All
{
   public class PartAllViewModel : IMapFrom<PartServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string AcquiredFrom { get; set; }

        public int Stock { get; set; }

        public int UsedCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<PartServiceModel, PartAllViewModel>()
                .ForMember(dest => dest.AcquiredFrom, opts => opts.MapFrom(x => x.AcquiredFrom.Name));

        }
    }
}
