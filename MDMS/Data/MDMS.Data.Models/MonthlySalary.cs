using System.ComponentModel.DataAnnotations;
using Mdms.Data.Models;

namespace MDMS.Data.Models
{
    public class MonthlySalary: Base
    {
        [Range(1, 12)]
        public int Month { get; set; }

        [Range(1900, 2200)]
        public int Year { get; set; }

        public string MechanicId { get; set; }
        public MdmsUser Mechanic { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "999999999")]
        public decimal AdditionalOnHourPayment { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "999999999")]
        public decimal BaseSalary { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "999999999")]
        public decimal TotalSalary { get; set; }

        [Range(0, 1000)]
        public double HoursWorked { get; set; }
    }
}
