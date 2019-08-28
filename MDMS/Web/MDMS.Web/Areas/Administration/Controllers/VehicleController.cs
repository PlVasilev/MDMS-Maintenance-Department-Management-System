using System;
using System.Threading.Tasks;
using MDMS.GlobalConstants;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Vehicle.Create;
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

                this.ViewData["error"] = ControllerConstants.VehicleProviderCreateErrorMessage;
                return this.View("Provider/Create", vehicleProviderBindingModel);
            }
            this.ViewData["error"] = ControllerConstants.InputErrorMessage;
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

                this.ViewData["error"] = ControllerConstants.VehicleTypeCreateErrorMessage;
                return this.View("Type/Create", vehicleTypeCreateBindingModel);
            }
            this.ViewData["error"] = ControllerConstants.InputErrorMessage;
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

                this.ViewData["error"] = ControllerConstants.VehicleCreateErrorMessage;
                return this.View(vehicleCreateBindingModel);
            }
            this.ViewData["error"] = ControllerConstants.InputErrorMessage;
            return this.View(vehicleCreateBindingModel);
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(string name)
        {
            try
            {
                return await Task.Run((() =>
                    this.View(_vehicleService.GetVehicleByName(name).To<VehicleEditViewModel>())));
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction("All");
        } 


        [HttpPost(Name = "Edit")]
        public async Task<IActionResult> Edit(VehicleEditBindingModel vehicleEditBindingModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _vehicleService.Edit(vehicleEditBindingModel.To<VehicleServiceModel>());

                if (result)
                {
                    this.ViewData["error"] = ControllerConstants.VehicleEditErrorMessage;
                    return this.Redirect($"/Vehicle/Details?name={vehicleEditBindingModel.Name}");
                }

                return this.RedirectToAction("Edit", vehicleEditBindingModel);
            }
            this.ViewData["error"] = ControllerConstants.InputErrorMessage;
            return this.RedirectToAction("Edit", vehicleEditBindingModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _vehicleService.DeleteVehicle(id);
            return RedirectToAction("All");
        }
    }
}