using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Vehicle.Create;
using MDMS.Web.ViewModels.Vehicle.Details;
using MDMS.Web.ViewModels.Vehicle.Edit;
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
        public async Task<IActionResult> CreateProvider() => await Task.Run(() => this.View("Provider/Create"));


        [HttpPost]
        [Route("/Administration/Vehicle/Provider/Create")]
        public async Task<IActionResult> CreateProvider(VehicleProviderCreateBindingModel vehicleProviderBindingModel)
        {
            if (ModelState.IsValid)
            {
                VehicleProviderServiceModel vehicleProviderServiceModel =
                    AutoMapper.Mapper.Map<VehicleProviderServiceModel>(vehicleProviderBindingModel);

                var result = await _vehicleService.CreateVehicleProvider(vehicleProviderServiceModel);

                if (result) return this.Redirect("/");

                this.ViewData["error"] =
                    "Vehicle Provider whit that name already Exists, change Vehicle provider name.";
                return this.View("Provider/Create", vehicleProviderBindingModel);
            }

            return this.View("Provider/Create", vehicleProviderBindingModel);
        }

        [HttpGet]
        [Route("/Administration/Vehicle/Type/Create")]
        public async Task<IActionResult> CreateType() => await Task.Run(() => this.View("Type/Create"));

        [HttpPost]
        [Route("/Administration/Vehicle/Type/Create")]
        public async Task<IActionResult> CreateType(VehicleTypeCreateBindingModel vehicleTypeCreateBindingModel)
        {
            if (ModelState.IsValid)
            {
                VehicleTypeServiceModel vehicleTypeServiceModel =
                    AutoMapper.Mapper.Map<VehicleTypeServiceModel>(vehicleTypeCreateBindingModel);

                var result = await _vehicleService.CreateVehicleType(vehicleTypeServiceModel);

                if (result) return this.Redirect("/");

                this.ViewData["error"] = "Vehicle Type whit that name already Exists, change Vehicle provider name.";
                return this.View("Type/Create", vehicleTypeCreateBindingModel);
            }

            return this.View("Type/Create", vehicleTypeCreateBindingModel);
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create() => await Task.Run(this.View);


        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(VehicleCreateBindingModel vehicleCreateBindingModel)
        {
            if (ModelState.IsValid)
            {
                string pictureUrl = await _cloudinaryService.UploadPictureAsync(vehicleCreateBindingModel.Picture,
                    vehicleCreateBindingModel.VSN);

                VehicleServiceModel vehicleServiceModel =
                    AutoMapper.Mapper.Map<VehicleServiceModel>(vehicleCreateBindingModel);
                vehicleServiceModel.Picture = pictureUrl;

                var result = await _vehicleService.Create(vehicleServiceModel);

                if (result) return this.Redirect("/");

                this.ViewData["error"] = "Vehicle VSN already Exists, change VSN.";
                return this.View(vehicleCreateBindingModel);
            }

            return this.View(vehicleCreateBindingModel);
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(string name) => await Task.Run((() => 
            this.View(_vehicleService.GetVehicleByName(name).To<VehicleEditViewModel>())));


        [HttpPost(Name = "Edit")]
        public async Task<IActionResult> Edit(VehicleEditBindingModel vehicleEditBindingModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _vehicleService.Edit(vehicleEditBindingModel.To<VehicleServiceModel>());

                if (result) return this.Redirect($"/Vehicle/Details?name={vehicleEditBindingModel.Name}");

                return this.RedirectToAction("Edit", vehicleEditBindingModel);
            }
            return this.RedirectToAction("Edit", vehicleEditBindingModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _vehicleService.DeleteVehicle(id);
            return RedirectToAction("All");
        }
    }
}