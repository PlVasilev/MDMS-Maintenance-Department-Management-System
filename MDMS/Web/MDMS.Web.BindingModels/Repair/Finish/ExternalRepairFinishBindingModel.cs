using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Repair.Finish
{
    public class ExternalRepairFinishBindingModel : IMapFrom<ExternalRepairServiceModel>, IMapTo<ExternalRepairServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string VehicleName { get; set; }

        [Required]
        [MaxLength(ModelConstants.NameLengthLg, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthStringLg)]
        public string Description { get; set; }


        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal LaborCost { get; set; }

        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal PartsCost { get; set; }
    }
}
