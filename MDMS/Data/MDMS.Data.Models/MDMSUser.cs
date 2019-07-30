using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MDMS.Data.Models;

namespace Mdms.Data.Models
{
    public class MdmsUser : IdentityUser<string>
    {
        public MdmsUser()
        { 
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "1000000")]
        public decimal BaseSalary { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "1000")]
        public decimal AdditionalOnHourPayment { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsAuthorized { get; set; } = false;

        public ICollection<MonthlySalary> Salaries { get; set; } = new HashSet<MonthlySalary>();

        public ICollection<InternalRepair> InternalRepairs { get; set; } = new HashSet<InternalRepair>();
        public ICollection<ExternalRepair> ExternalRepairs { get; set; } = new HashSet<ExternalRepair>();
    }
}
