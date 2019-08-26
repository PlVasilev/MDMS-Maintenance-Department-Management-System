using System.Collections.Generic;
using System.Threading.Tasks;
using Mdms.Data.Models;
using MDMS.GlobalConstants;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Repair.Create;
using MDMS.Web.BindingModels.Repair.Finish;
using MDMS.Web.ViewModels.Repair.Finish;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Areas.Administration.Controllers
{
    public class RepairController : AdminController
    {
        private readonly IRepairService _repairService;
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<MdmsUser> _userManager;

        public RepairController(IRepairService repairService, IVehicleService vehicleService, UserManager<MdmsUser> userManager)
        {
            _repairService = repairService;
            _vehicleService = vehicleService;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("/Administration/Repair/Provider/Create")]
        public async Task<IActionResult> CreateProvider() => await Task.Run(() => this.View("Provider/Create"));


        [HttpPost]
        [Route("/Administration/Repair/Provider/Create")]
        public async Task<IActionResult> CreateProvider(ExternalRepairProviderCreateBindingModel externalRepairProviderBindingModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleProviderServiceModel = AutoMapper.Mapper.Map<ExternalRepairProviderServiceModel>(externalRepairProviderBindingModel);

                var result = await _repairService.CreateExternalRepairProvider(vehicleProviderServiceModel);

                if (result) return this.Redirect("/");

                this.ViewData["error"] = ControllerConstants.RepairProviderCreateErrorMessage;
                return this.View("Provider/Create", externalRepairProviderBindingModel);
            }
            this.ViewData["error"] = ControllerConstants.InputErrorMessage;
            return this.View("Provider/Create", externalRepairProviderBindingModel);
        }

        [HttpGet(Name = "CreateExternal")]
        public async Task<IActionResult> CreateExternal(string name) => await Task.Run(() =>
            this.View(_vehicleService.GetVehicleByName(name).To<ExternalRepairCreateBindingModel>()));


        [HttpPost(Name = "CreateExternal")]
        public async Task<IActionResult> CreateExternal(ExternalRepairCreateBindingModel externalRepairCreateBindingModel)
        {
            if (ModelState.IsValid)
            {
                var externalRepairServiceModel = externalRepairCreateBindingModel.To<ExternalRepairServiceModel>();
                externalRepairServiceModel.MdmsUserId = _userManager.GetUserId(User);
                externalRepairServiceModel.RepairedSystem = new RepairedSystemServiceModel { Name = externalRepairCreateBindingModel.RepairedSystemName };
                externalRepairServiceModel.ExternalRepairProvider = new ExternalRepairProviderServiceModel { Name = externalRepairCreateBindingModel.ExternalRepairProviderName };
                externalRepairServiceModel.Name = "External_" + externalRepairCreateBindingModel.Make + "_" +
                                                  externalRepairCreateBindingModel.Model + "_" +
                                                  externalRepairCreateBindingModel.VSN;
                var result = await _repairService.CreateExternal(externalRepairServiceModel);

                if (result) return this.Redirect("/");

                this.ViewData["error"] = ControllerConstants.RepairCreateErrorMessage;
                return this.View(externalRepairCreateBindingModel);
            }
            this.ViewData["error"] = ControllerConstants.InputErrorMessage;
            return this.View(externalRepairCreateBindingModel);
        }

        [HttpGet(Name = "ExternalActive")]
        public async Task<IActionResult> ExternalActive() => await Task.Run((() => this.View(
            AutoMapper.Mapper.Map<List<ExternalRepairActiveViewModel>>(_repairService.GetActiveRepairs(_userManager.GetUserId(User))))));

        [HttpGet(Name = "ExternalActiveFinish")]
        public async Task<IActionResult> ExternalActiveFinish(string name)
        {
          var repair = await _repairService.GetExternalActiveRepair(name);
          var viewRepair = AutoMapper.Mapper.Map<ExternalRepairFinishBindingModel>(repair);
          return this.View(viewRepair);
        }

        [HttpPost(Name = "ExternalActiveFinish")]
        public async Task<IActionResult> ExternalActiveFinish(ExternalRepairFinishBindingModel externalRepairFinishBindingModel)
        {
           
            if (!ModelState.IsValid)
            {
                this.ViewData["error"] = ControllerConstants.InputErrorMessage;
                return this.View(externalRepairFinishBindingModel);
            }

            var result = await _repairService.FinalizeExternal(externalRepairFinishBindingModel.To<ExternalRepairServiceModel>());
            if (result) return this.Redirect("/");

            this.ViewData["error"] = ControllerConstants.RepairFinalizeErrorMessage;
            return this.View(externalRepairFinishBindingModel);
        }
    }
}