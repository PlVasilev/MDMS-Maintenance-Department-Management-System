using System.Collections.Generic;

namespace MDMS.Web.ViewModels.Repair.Home
{
    public class RepairActiveHomeViewModel 
    {
        public List<ExternalRepairActiveHomeViewModel> ExternalRepairActiveHomeViewModels = new List<ExternalRepairActiveHomeViewModel>();
        public List<InternalRepairActiveHomeViewModel> InternalRepairActiveHomeViewModels = new List<InternalRepairActiveHomeViewModel>();
    }
}
