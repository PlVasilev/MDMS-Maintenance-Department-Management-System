using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;

namespace MDMS.Web.BindingModels.Repair.Active
{
    public class ExternalRepairActiveEditDescriptionBindingModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.NameLengthLg, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthStringLg)]
        public string Description { get; set; }
    }
}
