using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Services.Mapping;
using Microsoft.AspNetCore.Mvc;
using MDMS.Web.Models;
using MDMS.Web.ViewModels.Repair.Home;

namespace MDMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepairService _repairService;

        public HomeController(IRepairService repairService)
        {
            _repairService = repairService;
        }

        public async Task<IActionResult> Index()
        {
            RepairActiveHomeViewModel repairActiveHomeViewModel = new RepairActiveHomeViewModel();

            var allExternalActiveRepairsServiceModel = await _repairService.GetAllExternalActiveRepairs();
            List<ExternalRepairActiveHomeViewModel> allExternalActiveRepairs = new List<ExternalRepairActiveHomeViewModel>();
            foreach (var allExternalRepairServiceModel in allExternalActiveRepairsServiceModel)
            {
                allExternalActiveRepairs.Add(allExternalRepairServiceModel.To<ExternalRepairActiveHomeViewModel>());
            }
            repairActiveHomeViewModel.ExternalRepairActiveHomeViewModels = allExternalActiveRepairs;

            var allInternalActiveRepairsServiceModel = await _repairService.GetAllInternalActiveRepairs();
            List<InternalRepairActiveHomeViewModel> allInternalActiveRepairs = new List<InternalRepairActiveHomeViewModel>();
            foreach (var internalExternalRepairServiceModel in allInternalActiveRepairsServiceModel)
            {
                allInternalActiveRepairs.Add(internalExternalRepairServiceModel.To<InternalRepairActiveHomeViewModel>());
            }
            repairActiveHomeViewModel.ExternalRepairActiveHomeViewModels = allExternalActiveRepairs;
            repairActiveHomeViewModel.InternalRepairActiveHomeViewModels = allInternalActiveRepairs;


            return this.View(repairActiveHomeViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
