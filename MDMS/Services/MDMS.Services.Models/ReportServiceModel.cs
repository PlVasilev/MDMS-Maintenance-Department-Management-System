using System.Collections.Generic;
using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
   public class ReportServiceModel : BaseServiceModel, IMapFrom<Report>, IMapTo<Report>
    {

        public int StartMonth { get; set; }

        public int StartYear { get; set; }

        public int EndMonth { get; set; }

        public int EndYear { get; set; }

        public string ReportTypeId { get; set; }
        public ReportTypeServiceModel ReportType { get; set; }

        public decimal ExternalRepairCosts { get; set; }
        public decimal InternalRepairCosts { get; set; }
        public decimal MechanicsBaseCosts { get; set; }
        public decimal VehicleBaseCost { get; set; }
        public ICollection<VehicleServiceModel> VehiclesInReport { get; set; } = new HashSet<VehicleServiceModel>();
        public ICollection<MonthlySalaryServiceModel> MonthlySalariesInReport { get; set; } = new HashSet<MonthlySalaryServiceModel>();
        
    }
}
