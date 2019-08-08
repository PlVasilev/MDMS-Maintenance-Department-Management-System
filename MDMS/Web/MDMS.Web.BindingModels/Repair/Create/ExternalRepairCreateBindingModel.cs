using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Repair.Create
{
    public class ExternalRepairCreateBindingModel : IMapFrom<VehicleServiceModel>, IMapTo<ExternalRepairServiceModel>, IHaveCustomMappings
    {
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string RepairedSystemName { get; set; }

        [Required]
        public string VSN { get; set; }

        [Required]
        public string VehicleId { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string ExternalRepairProviderName { get; set; }

        [Required]
        public string Model { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<VehicleServiceModel, ExternalRepairCreateBindingModel>()
                .ForMember(dest => dest.VehicleId, opts => opts.MapFrom(x => x.Id));
        }
    }
}
