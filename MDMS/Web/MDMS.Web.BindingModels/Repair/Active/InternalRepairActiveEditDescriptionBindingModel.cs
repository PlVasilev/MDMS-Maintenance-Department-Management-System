using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;

namespace MDMS.Web.BindingModels.Repair.Active
{
   public class InternalRepairActiveEditDescriptionBindingModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.NameLengthLg, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthStringLg)]
        public string Description { get; set; }
    }
}
