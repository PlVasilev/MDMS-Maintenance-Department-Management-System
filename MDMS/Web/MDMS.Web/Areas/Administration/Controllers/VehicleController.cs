using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Services.Models;
using MDMS.Web.BindingModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

            return this.View();
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(VehicleCreateBindingModel vehicleCreateBindingModel)
        {
            VehicleServiceModel vehicleServiceModel = new VehicleServiceModel()
            {
                Make = vehicleCreateBindingModel.Make,
                Model = vehicleCreateBindingModel.Model,
                VSN = vehicleCreateBindingModel.VSN,
                AcquiredBy = new VehicleProviderServiceModel() { Name = vehicleCreateBindingModel.AcquiredBy},
                AcquiredOn = vehicleCreateBindingModel.AcquiredOn,
                Depreciation = vehicleCreateBindingModel.Depreciation,
                ManufacturedOn = vehicleCreateBindingModel.ManufacturedOn,
                VehicleType = new VehicleTypeServiceModel() { Name = vehicleCreateBindingModel.VehicleType}
            };

            await _vehicleService.Create(vehicleServiceModel);

            return this.Redirect("/");
        }
    }
}