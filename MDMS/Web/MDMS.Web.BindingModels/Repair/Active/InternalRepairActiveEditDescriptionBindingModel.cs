using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDMS.Web.BindingModels.Repair.Active
{
   public class InternalRepairActiveEditDescriptionBindingModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
