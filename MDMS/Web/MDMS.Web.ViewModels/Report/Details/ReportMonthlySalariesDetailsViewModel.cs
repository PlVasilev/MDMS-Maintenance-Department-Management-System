using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Web.ViewModels.Report.Details
{
   public class ReportMonthlySalariesDetailsViewModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string MechanicFirstName { get; set; }
        public string MechanicLastName { get; set; }
        public decimal AdditionalOnHourPayment { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal TotalSalary { get; set; }
        public double HoursWorked { get; set; }
    }
}
