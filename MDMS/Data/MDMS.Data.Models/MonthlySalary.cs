using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Range(1, 12)]
        public int Month { get; set; }

        [Range(1900, 2200)]
        public int Year { get; set; }

        public MdmsUser Mechanic { get; set; }

        public decimal TotalSalary => Mechanic.BaseSalary +
                                      ((decimal)Mechanic.MdmsUserRepairs
                                           .Where(x => x.Repair.FinishedOn != null &&
                                                       x.Repair.FinishedOn.Value.Month == Month &&
                                                       x.Repair.FinishedOn.Value.Year == Year)
                                           .Sum(x => x.HoursWorked) * (decimal)Mechanic.AdditionalOnHourPayment) * 1.18m;

        [Range(0, 1000)]
        public double HoursWorked { get; set; }

    }
}
