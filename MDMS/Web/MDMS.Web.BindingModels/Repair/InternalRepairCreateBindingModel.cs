using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Repair
{
   public class InternalRepairCreateBindingModel : IMapFrom<VehicleServiceModel>, IMapTo<InternalRepairServiceModel>
    {
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string RepairedSystem { get; set; }

        [Required]
        public string VSN { get; set; }

        [Required]
        public string VehicleId { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

    }
}
