using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Report.Details
{
   public class ReportDetailsViewModel : IMapFrom<ReportServiceModel>
    {
        public int StartMonth { get; set; }

        public int StartYear { get; set; }

        public int EndMonth { get; set; }

        public int EndYear { get; set; }

        public string ReportTypeName { get; set; }

        public decimal ExternalRepairCosts { get; set; }
        public decimal InternalRepairCosts { get; set; }
        public decimal MechanicsBaseCosts { get; set; }
        public decimal VehicleBaseCost { get; set; }

        public ICollection<ReportVehicleDetailsViewModel> VehiclesInReport { get; set; } = new HashSet<ReportVehicleDetailsViewModel>();
        public ICollection<MonthlySalaryServiceModel> MonthlySalariesInReport { get; set; } = new HashSet<MonthlySalaryServiceModel>();
    }
}
