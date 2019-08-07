using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Repair;
using MDMS.Web.ViewModels.Repair;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Controllers
{
    public class RepairController : UserController
    {
        private readonly IVehicleService _vehicleService;
        private readonly IRepairService _repairService;

        public RepairController(IVehicleService vehicleService, IRepairService repairService)
        {
            _vehicleService = vehicleService;
            _repairService = repairService;
        }

        [HttpGet(Name = "CreateInternal")]
        public async Task<IActionResult> CreateInternal(string name) => await Task.Run(() => 
            this.View(_vehicleService.GetVehicleByName(name).To<InternalRepairCreateBindingModel>()));


        [HttpPost(Name = "CreateInternal")]
        public async Task<IActionResult> CreateInternal(InternalRepairCreateBindingModel internalRepairCreateBindingModel)
        {
            if (ModelState.IsValid)
            {
                InternalRepairServiceModel internalRepairServiceModel = AutoMapper.Mapper.Map<InternalRepairServiceModel>(internalRepairCreateBindingModel);
               // var result = await _repairService.CreateInternal(internalRepairServiceModel);

               // if (result) return this.Redirect("/");

                this.ViewData["error"] = "Part with that name already exist.";
                return this.View(internalRepairCreateBindingModel);
            }
            return this.View(internalRepairCreateBindingModel);
        }
    }
}