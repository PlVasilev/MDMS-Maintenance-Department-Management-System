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

        public MDMSUserServiceModel Mechanic { get; set; }

        public decimal TotalSalary => Mechanic.BaseSalary +
                                      ((decimal)Mechanic.InternalRepairs
                                           .Where(x => x.FinishedOn != null &&
                                                       x.FinishedOn.Value.Month == Month &&
                                                       x.FinishedOn.Value.Year == Year)
                                           .Sum(x => x.HoursWorked) * (decimal)Mechanic.AdditionalOnHourPayment) * 1.18m;
        public double HoursWorked { get; set; }
    }
}
