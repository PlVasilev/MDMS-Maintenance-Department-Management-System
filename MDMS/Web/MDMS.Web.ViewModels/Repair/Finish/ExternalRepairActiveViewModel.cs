using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Repair.Finish
{
   public class ExternalRepairActiveViewModel : IMapFrom<ExternalRepairServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public string VehicleMake { get; set; }

        public string VehiclePicture { get; set; }

        public string VehicleModel { get; set; }

        public string VehicleVSN { get; set; }

        public string RepairedSystemName { get; set; }

        public string MdmsUserUsername { get; set; }

        public int Mileage { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime? FinishedOn { get; set; } = null;

        public string ExternalRepairProviderName { get; set; }

        [Range(typeof(decimal), "0.00", "9999999999", ErrorMessage = "Must be positive number")]
        public decimal LaborCost { get; set; }

        [Range(typeof(decimal), "0.00", "9999999999", ErrorMessage = "Must be positive number")]
        public decimal PartsCost { get; set; }
    }
}
