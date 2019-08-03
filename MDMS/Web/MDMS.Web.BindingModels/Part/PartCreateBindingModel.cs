using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Vehicle;
using Microsoft.AspNetCore.Http;

namespace MDMS.Web.BindingModels.Part
{
    public class PartCreateBindingModel : IMapTo<PartServiceModel>, IHaveCustomMappings
    {
        [Required]
        [StringLength(50, ErrorMessage = "Must not be empty and less than 50 symbols.")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "999999999", ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0,int.MaxValue, ErrorMessage = "Must be 0 or more.")]
        public int Stock { get; set; }

        [Required]
        public string AcquiredFrom { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<PartCreateBindingModel, PartServiceModel>()
                .ForMember(dest => dest.AcquiredFrom,
                    opts => opts.MapFrom(org => new PartsProviderServiceModel() {Name = org.AcquiredFrom}));
        }
    } 
}
