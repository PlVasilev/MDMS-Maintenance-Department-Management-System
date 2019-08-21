using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mdms.Data.Models;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Repair;
using MDMS.Web.BindingModels.Repair.Active;
using MDMS.Web.BindingModels.Repair.Create;
using MDMS.Web.ViewModels.Repair;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Controllers
{
    public class RepairController : UserController
    {
        private readonly IVehicleService _vehicleService;
        private readonly IRepairService _repairService;
        private readonly UserManager<MdmsUser> _userManager;

        public RepairController(IVehicleService vehicleService, IRepairService repairService, UserManager<MdmsUser> userManager)
        {
            _vehicleService = vehicleService;
            _repairService = repairService;
            _userManager = userManager;
        }

        [HttpGet(Name = "CreateInternal")]
        public async Task<IActionResult> CreateInternal(string name) => await Task.Run(() => 
            this.View(_vehicleService.GetVehicleByName(name).To<InternalRepairCreateBindingModel>()));


        [HttpPost(Name = "CreateInternal")]
        public async Task<IActionResult> CreateInternal(InternalRepairCreateBindingModel internalRepairCreateBindingModel)
        {
            if (ModelState.IsValid)
            {
                var internalRepairServiceModel = internalRepairCreateBindingModel.To<InternalRepairServiceModel>();
                internalRepairServiceModel.MdmsUserId = _userManager.GetUserId(User);
                internalRepairServiceModel.RepairedSystem = new RepairedSystemServiceModel {Name = internalRepairCreateBindingModel.RepairedSystemName};
                internalRepairServiceModel.Name = "Internal_" + internalRepairCreateBindingModel.Make + "_" +
                                                  internalRepairCreateBindingModel.Model + "_" +
                                                  internalRepairCreateBindingModel.VSN;
                var result = await _repairService.CreateInternal(internalRepairServiceModel);

                if (result) return this.Redirect("/");

                this.ViewData["error"] = "User has already started a repair or Repair with that name already exists.";
                return this.View(internalRepairCreateBindingModel);
            }
            return this.View(internalRepairCreateBindingModel);
        }

        [HttpGet(Name = "InternalActive")]
        public async Task<IActionResult> InternalActive() => this.View(
            AutoMapper.Mapper.Map<InternalRepairActiveBindingModel>(await _repairService.GetActiveRepair(_userManager.GetUserId(User))));

        [HttpGet(Name = "InternalActiveFinish")]
        public async Task<IActionResult> InternalActiveFinish(string id)
        {
            await _repairService.FinalizeInternal(id);
            return Redirect("/");
        }

    }
}