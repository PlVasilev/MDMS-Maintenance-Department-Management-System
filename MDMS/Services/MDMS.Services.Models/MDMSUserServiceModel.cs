using System;
using System.Collections.Generic;
using System.Text;
using Mdms.Data.Models;
using MDMS.Data.Models;
using MDMS.Services.Mapping;
using Microsoft.AspNetCore.Identity;

namespace MDMS.Services.Models
{
    public class MDMSUserServiceModel : IdentityUser, IMapFrom<MdmsUser>, IMapTo<MdmsUser>
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal BaseSalary { get; set; }

        public decimal AdditionalOnHourPayment { get; set; }

        public bool IsRepairing { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsAuthorized { get; set; } = false;

        public ICollection<MonthlySalaryServiceModel> Salaries { get; set; } = new HashSet<MonthlySalaryServiceModel>();

        public ICollection<InternalRepairServiceModel> InternalRepairs { get; set; } = new HashSet<InternalRepairServiceModel>();
        public ICollection<ExternalRepairServiceModel> ExternalRepairs { get; set; } = new HashSet<ExternalRepairServiceModel>();
    }
}
 