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

        public bool IsAuthorized { get; set; } = false;

        public ICollection<MonthlySalary> Salaries { get; set; } = new HashSet<MonthlySalary>();

        public ICollection<MdmsUserRepair> MdmsUserRepairs { get; set; } = new HashSet<MdmsUserRepair>();

    }
}
