using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Repair.Finish
{
    public class ExternalRepairFinishBindingModel : IMapTo<ExternalRepairServiceModel>
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }


        [Range(typeof(decimal), "0.00", "9999999999", ErrorMessage = "Must be positive number")]
        public decimal LaborCost { get; set; }

        [Range(typeof(decimal), "0.00", "9999999999", ErrorMessage = "Must be positive number")]
        public decimal PartsCost { get; set; }
    }
}
