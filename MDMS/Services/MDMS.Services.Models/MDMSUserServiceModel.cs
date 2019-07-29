using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
    public class MDMSUserServiceModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal BaseSalary { get; set; }

        public decimal AdditionalOnHourPayment { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsAuthorized { get; set; } = false;

        public ICollection<MonthlySalaryServiceModel> Salaries { get; set; } = new HashSet<MonthlySalaryServiceModel>();

        public ICollection<RepairServiceModel>Repairs { get; set; } = new HashSet<RepairServiceModel>();
    }
}
 