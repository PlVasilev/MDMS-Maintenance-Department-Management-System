using System;
using System.Threading.Tasks;
using Mdms.Data.Models;
using MDMS.GlobalConstants;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Repair.Active;
using MDMS.Web.BindingModels.Repair.Create;
using MDMS.Web.ViewModels.Repair.All;
using MDMS.Web.ViewModels.Repair.Details;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                internalRepairServiceModel.RepairedSystem = new RepairedSystemServiceModel { Name = internalRepairCreateBindingModel.RepairedSystemName };
                internalRepairServiceModel.Name = "Internal_" +
                                                  internalRepairCreateBindingModel.RepairedSystemName + "_" +
                                                  internalRepairCreateBindingModel.Make + "_" +
                                                  internalRepairCreateBindingModel.Model + "_" +
                                                  internalRepairCreateBindingModel.VSN;
                var result = await _repairService.CreateInternal(internalRepairServiceModel);

                if (result) return this.Redirect("/");

                this.ViewData["error"] = ControllerConstants.RepairCreateErrorMessage;
                return this.View(internalRepairCreateBindingModel);
            }
            this.ViewData["error"] = ControllerConstants.InputErrorMessage;
            return this.View(internalRepairCreateBindingModel);
        }

        [HttpGet(Name = "InternalActive")]
        public async Task<IActionResult> InternalActive() => this.View(
            AutoMapper.Mapper.Map<InternalRepairActiveBindingModel>(await _repairService.GetActiveRepair(_userManager.GetUserId(User))));

        [HttpPost(Name = "InternalActiveFinish")]
        public async Task<IActionResult> InternalActiveFinish(InternalRepairActiveBindingModel internalRepairActiveBindingModel)
        {
            if (!ModelState.IsValid)
            {
                this.ViewData["error"] = ControllerConstants.InputErrorMessage;
                return RedirectToAction("InternalActive");
            }
            var result = await _repairService.FinalizeInternal(internalRepairActiveBindingModel.Id, internalRepairActiveBindingModel.HoursWorked);
            if (!result)
            {
                this.ViewData["error"] = ControllerConstants.RepairFinalizeErrorMessage;
                return RedirectToAction("InternalActive");
            }
            return Redirect("/");
        }


        [HttpGet(Name = "All")]
        public async Task<IActionResult> All() => View(new RepairsAllViewModel
        {
            ExternalRepairAllViewModels = await _repairService.GetAllExternalRepairs().To<ExternalRepairAllViewModel>().ToListAsync(),
            InternalRepairAllViewModels = await _repairService.GetAllInternalRepairs().To<InternalRepairAllViewModel>().ToListAsync()
        });

        [HttpGet(Name = "InternalDetails")]
        public async Task<IActionResult> InternalDetails(string name)
        {
            try
            {
                return await Task.Run((() =>
                    View(_repairService.GetInternalRepairByName(name.Replace(" ", "_")).Result.To<InternalRepairDetailsViewModel>())));
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction("All");
        }
       

        [HttpGet(Name = "ExternalDetails")]
        public async Task<IActionResult> ExternalDetails(string name)
        {
            try
            {
                return await Task.Run((() =>
                    View(_repairService.GetExternalRepairByName(name.Replace(" ", "_")).Result.To<ExternalRepairDetailsViewModel>())));
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction("All");
        }
    }
}