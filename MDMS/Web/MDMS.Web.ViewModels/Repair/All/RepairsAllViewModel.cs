using System.Collections.Generic;

namespace MDMS.Web.ViewModels.Repair.All
{
    public class RepairsAllViewModel
    {
       public  List<ExternalRepairAllViewModel> ExternalRepairAllViewModels = new List<ExternalRepairAllViewModel>();

       public List<InternalRepairAllViewModel> InternalRepairAllViewModels = new List<InternalRepairAllViewModel>();
    }
}
