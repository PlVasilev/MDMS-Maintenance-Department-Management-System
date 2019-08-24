using System.Linq;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
   public class MonthlySalaryServiceModel : BaseServiceModel, IMapFrom<MonthlySalary>, IMapTo<MonthlySalary>
   {
    
         //=> Year + " " + Month + " " + Mechanic.FirstName + " " + Mechanic.LastName;

        public int Month { get; set; }

        public int Year { get; set; }

        public string MechanicId { get; set; }
        public MDMSUserServiceModel Mechanic { get; set; }

        public decimal AdditionalOnHourPayment { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal TotalSalary { get; set; }

        public double HoursWorked { get; set; }
    }
}
