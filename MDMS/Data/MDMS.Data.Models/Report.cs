using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdms.Data.Models;

namespace MDMS.Data.Models
{
   public class Report
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string ReportTypeId { get; set; }
        public ReportType ReportType { get; set; }

        public ICollection<Repair> Repairs { get; set; } = new HashSet<Repair>();

        public ICollection<MdmsUser> Users { get; set; } = new HashSet<MdmsUser>();

        public ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();

        public ICollection<Repair> RepairsInReport => Repairs.Where(y => y.FinishedOn >= Start && y.FinishedOn <= End).ToHashSet();

        public decimal RepairsConst => RepairsInReport.Sum(z => z.RepairParts.Sum(c => c.Part.Price * c.Quantity));

        public ICollection<Vehicle> RepairedVehicles => RepairsInReport.Select(x => x.Vehicle).ToHashSet();

        public decimal BaseCost => (Users.Sum(x => x.BaseSalary) + Vehicles.Sum(x => x.Depreciation)) *
                                   (End.Month - Start.Month + 1) + (12 * (End.Year - Start.Year));

    }
}
