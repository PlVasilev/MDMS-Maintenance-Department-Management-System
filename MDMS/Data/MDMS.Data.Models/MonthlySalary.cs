using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Mdms.Data.Models;

namespace MDMS.Data.Models
{
    public class MonthlySalary: Base
    {
        [Range(1, 12)]
        public int Month { get; set; }

        [Range(1900, 2200)]
        public int Year { get; set; }

        public MdmsUser Mechanic { get; set; }

        public decimal TotalSalary => Mechanic.BaseSalary +
                                      ((decimal)Mechanic.InternalRepairs
                                           .Where(x => x.FinishedOn != null &&
                                                       x.FinishedOn.Value.Month == Month &&
                                                       x.FinishedOn.Value.Year == Year)
                                           .Sum(x => x.HoursWorked) * (decimal)Mechanic.AdditionalOnHourPayment) * 1.18m;

        [Range(0, 1000)]
        public double HoursWorked { get; set; }
    }
}
