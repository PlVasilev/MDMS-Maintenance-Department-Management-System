using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MDMS.Data.Models;
using MDMS.GlobalConstants;

namespace Mdms.Data.Models
{
    public class MdmsUser : IdentityUser<string>
    {
        public MdmsUser()
        { 
        }

        public bool IsRepairing { get; set; }

        [Required]
        [MaxLength(ModelConstants.NameLength, ErrorMessage =  ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthString)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ModelConstants.NameLengthSm, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthStringSm)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ModelConstants.NameLengthSm, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthStringSm)]
        public string LastName { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal BaseSalary { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal AdditionalOnHourPayment { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsAuthorized { get; set; } = false;

        public ICollection<MonthlySalary> Salaries { get; set; } = new HashSet<MonthlySalary>();

        public ICollection<InternalRepair> InternalRepairs { get; set; } = new HashSet<InternalRepair>();
        public ICollection<ExternalRepair> ExternalRepairs { get; set; } = new HashSet<ExternalRepair>();
    }
}
