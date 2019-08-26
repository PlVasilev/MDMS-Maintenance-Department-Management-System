using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Report.Details
{
    public class ReportInternalRepairDetailsRepairPartViewModel : IMapFrom<InternalRepairPartServiceModel>
    {
        public string PartName { get; set; }
        public bool PartIsDeleted { get; set; }
        public string PartAcquiredFromName { get; set; }
        public decimal PartPrice { get; set; }
        public int Quantity { get; set; }
    }
}
