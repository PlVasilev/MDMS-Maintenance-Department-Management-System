using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Part.Edit
{
    public class PartEditViewModel : IMapFrom<PartServiceModel>,IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Must not be empty and less than 50 symbols.")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "999999999", ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }

        public int UsedCount { get; set; }


        [Required]
        public string AcquiredFrom { get; set; }

        public int Stock { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<PartServiceModel, PartEditViewModel>()
                .ForMember(dest => dest.AcquiredFrom,
                    opts => opts.MapFrom(org => org.AcquiredFrom.Name));

        }
    }
}
