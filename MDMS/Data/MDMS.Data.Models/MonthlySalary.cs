using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Mdms.Data.Models;

namespace MDMS.Data.Models
{
    public class MonthlySalary
    {
        public string Id { get; set; }

        public string SalarySlipTitle => Year + " " + Month + " " + Mechanic.FirstName + " " + Mechanic.LastName;

        public int Month { get; set; }

        public int Year { get; set; }

        public MdmsUser Mechanic { get; set; }

        public decimal TotalSalary => Mechanic.BaseSalary + 
                                      ((decimal) Mechanic.MdmsUserRepairs
                                           .Where(x => x.Repair.FinishedOn.Month == Month && 
                                                       x.Repair.FinishedOn.Year == Year)
                                           .Sum(x => x.HoursWorked) * (decimal) Mechanic.AdditionalOnHourPayment) * 1.18m;

        public double HoursWorked { get; set; }

    }
}
