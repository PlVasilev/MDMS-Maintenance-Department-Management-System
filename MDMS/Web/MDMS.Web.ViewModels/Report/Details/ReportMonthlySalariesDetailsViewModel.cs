using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Report.Details
{
   public class ReportMonthlySalariesDetailsViewModel : IMapFrom<MonthlySalaryServiceModel>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string MechanicFirstName { get; set; }
        public string MechanicLastName { get; set; }
        public decimal AdditionalOnHourPayment { get; set; }
        public decimal BaseSalary { get; set; }
        public double HoursWorked { get; set; }
    }
}
