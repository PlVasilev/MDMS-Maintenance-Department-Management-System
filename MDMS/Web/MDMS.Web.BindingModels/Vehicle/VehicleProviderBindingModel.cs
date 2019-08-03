﻿using System.ComponentModel.DataAnnotations;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Vehicle
{
    public class VehicleProviderBindingModel : IMapTo<VehicleProviderServiceModel>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
