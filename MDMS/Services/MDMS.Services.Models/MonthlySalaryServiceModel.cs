using System.Linq;

namespace MDMS.Services.Models
{
   public class MonthlySalaryServiceModel
    {
        public string Id { get; set; }

        public string SalarySlipTitle => Year + " " + Month + " " + Mechanic.FirstName + " " + Mechanic.LastName;

        public int Month { get; set; }

        public int Year { get; set; }

        public MDMSUserServiceModel Mechanic { get; set; }

        public decimal TotalSalary => Mechanic.BaseSalary +
                                      ((decimal)Mechanic.MdmsUserRepairs
                                           .Where(x => x.Repair.FinishedOn != null &&
                                                       x.Repair.FinishedOn.Value.Month == Month &&
                                                       x.Repair.FinishedOn.Value.Year == Year)
                                           .Sum(x => x.HoursWorked) * (decimal)Mechanic.AdditionalOnHourPayment) * 1.18m;
        public double HoursWorked { get; set; }
    }
}
