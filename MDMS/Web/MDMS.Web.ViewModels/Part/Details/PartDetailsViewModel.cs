using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Part.Details
{
    public class PartDetailsViewModel : IMapFrom<PartServiceModel>, IHaveCustomMappings
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int UsedCount { get; set; }
        
        public string AcquiredFromName { get; set; }

        public List<PartDetailsInternalRepairPartViewModel> InternalRepairParts { get; set; } = new List<PartDetailsInternalRepairPartViewModel>();

        [Range(ModelConstants.IntPositiveMin, ModelConstants.IntMax, ErrorMessage = ModelConstants.PositiveNumberFromOneErrorMessage)]
        public int Quantity { get; set; }
        public int Stock { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<PartServiceModel, PartDetailsViewModel>()
                .ForMember(d => d.Name,
                    o => o.MapFrom(x => x.Name.Replace("_", " ")));
        }
    }
}
