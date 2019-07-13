using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using MDMS.Data.Models;

namespace Mdms.Data.Models
{
    public class MdmsUser : IdentityUser<string>
    {
        public MdmsUser()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal BaseSalary { get; set; }

        public decimal AdditionalOnHourPayment { get; set; }

        public bool IsAuthorized { get; set; } = false;

        public ICollection<MonthlySalary> Salaries { get; set; } = new HashSet<MonthlySalary>();

        public ICollection<MdmsUserRepair> MdmsUserRepairs { get; set; } = new HashSet<MdmsUserRepair>();

    }
}
