using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Repair.Active
{
    public class InternalRepairActiveRepairPartBindingModel : IMapFrom<InternalRepairPartServiceModel>
    {
        public string PartName { get; set; }
        public string PartAcquiredFromName { get; set; }
        public decimal PartPrice { get; set; }
        public int Quantity { get; set; }
    }
}
