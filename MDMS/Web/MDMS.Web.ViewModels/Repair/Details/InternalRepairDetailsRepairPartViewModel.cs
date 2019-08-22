using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Repair.Details
{
   public class InternalRepairDetailsRepairPartViewModel : IMapFrom<InternalRepairPartServiceModel>
    {
        public string PartName { get; set; }
        public string PartAcquiredFromName { get; set; }
        public decimal PartPrice { get; set; }
        public int Quantity { get; set; }
    }
}
