using System;
using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Repair.Finish
{
   public class ExternalRepairActiveViewModel : IMapFrom<ExternalRepairServiceModel>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [Required]
        [MaxLength(ModelConstants.NameLengthLg, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthStringLg)]
        public string Description { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleName { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleVSN { get; set; }
        public string RepairedSystemName { get; set; }
        public string MdmsUserUsername { get; set; }
        public int Mileage { get; set; }
        public DateTime StartedOn { get; set; }
        public string ExternalRepairProviderName { get; set; }
    }
}
