using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Repair;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Areas.Administration.Controllers
{
    public class RepairController : AdminController
    {
        private readonly IRepairService _repairService;

        public RepairController(IRepairService repairService)
        {
            _repairService = repairService;
        }
        [HttpGet]
        [Route("/Administration/Repair/Provider/Create")]
        public async Task<IActionResult> CreateProvider() => await Task.Run(() => this.View("Provider/Create"));


        [HttpPost]
        [Route("/Administration/Repair/Provider/Create")]
        public async Task<IActionResult> CreateProvider(ExternalRepairProviderBindingModel externalRepairProviderBindingModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleProviderServiceModel = AutoMapper.Mapper.Map<ExternalRepairProviderServiceModel>(externalRepairProviderBindingModel);

                var result = await _repairService.CreateExternalRepairProvider(vehicleProviderServiceModel);

                if (result) return this.Redirect("/");

                this.ViewData["error"] = "Repair Provider whit that name already Exists, change Repair provider name.";
                return this.View("Provider/Create", externalRepairProviderBindingModel);
            }
            return this.View("Provider/Create", externalRepairProviderBindingModel);
        }
    }
}