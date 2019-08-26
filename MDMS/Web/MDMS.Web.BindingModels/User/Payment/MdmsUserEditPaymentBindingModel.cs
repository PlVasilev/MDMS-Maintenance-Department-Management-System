using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.User.Payment
{
    public class MdmsUserEditPaymentBindingModel: IMapTo<MDMSUserServiceModel>, IMapFrom<MDMSUserServiceModel>
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal BaseSalary { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal AdditionalOnHourPayment { get; set; }
    }
}
