using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Repair.Active
{
   public class InternalRepairActiveBindingModel : IMapFrom<InternalRepairServiceModel>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [Range(ModelConstants.DoublePositiveMin, ModelConstants.DoubleMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public double HoursWorked { get; set; }

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
        public DateTime? FinishedOn { get; set; } = null;
        public decimal RepairCost { get; set; }
        public List<InternalRepairActiveRepairPartBindingModel> InternalRepairParts { get; set; } = new List<InternalRepairActiveRepairPartBindingModel>();
    }
}
