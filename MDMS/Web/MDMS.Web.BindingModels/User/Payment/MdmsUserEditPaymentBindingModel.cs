using System.ComponentModel.DataAnnotations;
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
        [Range(typeof(decimal), "0.00", "1000000", ErrorMessage = "Must be positive number.")]
        public decimal BaseSalary { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "1000000", ErrorMessage = "Must be positive number.")]
        public decimal AdditionalOnHourPayment { get; set; }
    }
}
