using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Services.Models;
using MDMS.Web.BindingModels;
using MDMS.Web.BindingModels.Vehicle;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Areas.Administration.Controllers
{
    public class VehicleController : AdminController
    {
        private readonly IVehicleService _vehicleService;
        private readonly ICloudinaryService _cloudinaryService;

        public VehicleController(IVehicleService vehicleService, ICloudinaryService cloudinaryService)
        {
            _vehicleService = vehicleService;
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        [Route("/Administration/Vehicle/Provider/Create")]
        public async Task<IActionResult> CreateProvider()
        {
            return await Task.Run(() => this.View("Provider/Create"));
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
            return await Task.Run(() => this.View("Type/Create"));

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
            return await Task.Run(() => this.View());
            
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(VehicleCreateBindingModel vehicleCreateBindingModel)
        {

            if (ModelState.IsValid)
            {
                string pictureUrl = await _cloudinaryService.UploadPictureAsync(
                       vehicleCreateBindingModel.Picture,
                       vehicleCreateBindingModel.VSN);

                VehicleServiceModel vehicleServiceModel = new VehicleServiceModel()
                {
                    Name = vehicleCreateBindingModel.Make + "-" + vehicleCreateBindingModel.Model + "-" + vehicleCreateBindingModel.VSN,
                    Make = vehicleCreateBindingModel.Make,
                    Model = vehicleCreateBindingModel.Model,
                    VSN = vehicleCreateBindingModel.VSN,
                    VehicleProvider = new VehicleProviderServiceModel() { Name = vehicleCreateBindingModel.VehicleProvider },
                    AcquiredOn = vehicleCreateBindingModel.AcquiredOn,
                    Depreciation = vehicleCreateBindingModel.Depreciation,
                    ManufacturedOn = vehicleCreateBindingModel.ManufacturedOn,
                    VehicleType = new VehicleTypeServiceModel() { Name = vehicleCreateBindingModel.VehicleType },
                    Price = vehicleCreateBindingModel.Price,
                    Picture = pictureUrl
                };

                var result = await _vehicleService.Create(vehicleServiceModel);

                if (result) return this.Redirect("/");
                this.ViewData["error"] = "Vehicle VSN already Exists, change VSN.";
                return this.View(vehicleCreateBindingModel);

            }
            return this.View(vehicleCreateBindingModel);
        }

    }
}