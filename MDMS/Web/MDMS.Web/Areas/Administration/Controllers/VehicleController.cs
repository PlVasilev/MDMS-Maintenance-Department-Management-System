using System;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Services.Models;
using MDMS.Web.BindingModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using MDMS.Web.ViewModels;

namespace MDMS.Web.Areas.Administration.Controllers
{
    public class VehicleController : AdminController 
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        [Route("/Administration/Vehicle/Provider/Create")]
        public async Task<IActionResult> CreateProvider()
        {
            return this.View("Provider/Create");
        }

        [HttpPost]
        [Route("/Administration/Vehicle/Provider/Create")]
        public async Task<IActionResult> CreateProvider(VehicleProviderBindingModel vehicleProviderBindingModel)
        {
            VehicleProviderServiceModel vehicleProviderServiceModel = new VehicleProviderServiceModel()
            {
                Name = vehicleProviderBindingModel.Name
            };

            await _vehicleService.CreateVehicleProvider(vehicleProviderServiceModel);

            return this.Redirect("/");
        }

        [HttpGet]
        [Route("/Administration/Vehicle/Type/Create")]
        public async Task<IActionResult> CreateType()
        {
            return this.View("Type/Create");
        }

        [HttpPost]
        [Route("/Administration/Vehicle/Type/Create")]
        public async Task<IActionResult> CreateType(VehicleTypeCreateBindingModel vehicleTypeCreateBindingModel)
        {
            VehicleTypeServiceModel vehicleTypeServiceModel = new VehicleTypeServiceModel()
            {
                Name = vehicleTypeCreateBindingModel.Name
            };

            await _vehicleService.CreateVehicleType(vehicleTypeServiceModel);

            return this.Redirect("/");
        }


        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            await VehicleCreateViewData();
            return this.View();
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(VehicleCreateBindingModel vehicleCreateBindingModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    VehicleServiceModel vehicleServiceModel = new VehicleServiceModel()
                    {
                        Make = vehicleCreateBindingModel.Make,
                        Model = vehicleCreateBindingModel.Model,
                        VSN = vehicleCreateBindingModel.VSN,
                        VehicleProvider = new VehicleProviderServiceModel() { Name = vehicleCreateBindingModel.VehicleProvider },
                        AcquiredOn = vehicleCreateBindingModel.AcquiredOn,
                        Depreciation = vehicleCreateBindingModel.Depreciation,
                        ManufacturedOn = vehicleCreateBindingModel.ManufacturedOn,
                        VehicleType = new VehicleTypeServiceModel() { Name = vehicleCreateBindingModel.VehicleType }
                    };

                    var result = await _vehicleService.Create(vehicleServiceModel);

                    if (result) return this.Redirect("/");
                    await VehicleCreateViewData();
                    this.ViewData["error"] = "Vehicle VSN already Exists, change VSN.";
                    return this.View(vehicleCreateBindingModel);
                }
                catch (Exception ex)
                {
                   await VehicleCreateViewData();
                   this.ViewData["error"] = "Unexpected error: try again, if problem persists: Please contact administrator.";
                   return View(vehicleCreateBindingModel);
                }
            }
            await VehicleCreateViewData();
            return this.View(vehicleCreateBindingModel);
        }

        private async Task VehicleCreateViewData()
        {
            this.ViewData["error"] = null;

            var allVehicleTypes = await _vehicleService.GetAllVehicleTypes();
            this.ViewData["types"] = allVehicleTypes.Select(pt => new VehicleCreateVehicleTypeViewModel
            {
                Name = pt.Name
            }).ToList();

            var allVehicleProviders = await _vehicleService.GetAllVehicleProviders();

            this.ViewData["providers"] = allVehicleProviders.Select(pt => new VehicleCreateVehicleProviderViewModel()
            {
                Name = pt.Name
            }).ToList();
        }
    }
}