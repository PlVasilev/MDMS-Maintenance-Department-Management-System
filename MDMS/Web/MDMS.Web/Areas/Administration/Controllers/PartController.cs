using System;
using System.Threading.Tasks;
using MDMS.GlobalConstants;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Part.Add;
using MDMS.Web.BindingModels.Part.Create;
using MDMS.Web.BindingModels.Part.Edit;
using MDMS.Web.ViewModels.Part.Edit;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Areas.Administration.Controllers
{
    public class PartController : AdminController
    {
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        [HttpGet]
        [Route("/Administration/Part/Provider/Create")]
        public async Task<IActionResult> CreateProvider() => await Task.Run(() => this.View("Provider/Create"));


        [HttpPost]
        [Route("/Administration/Part/Provider/Create")]
        public async Task<IActionResult> CreateProvider(PartProviderBindingModel partProviderBindingModel)
        {
            if (ModelState.IsValid)
            {
                PartsProviderServiceModel vehicleProviderServiceModel = AutoMapper.Mapper.Map<PartsProviderServiceModel>(partProviderBindingModel);
                var result = await _partService.CreatePartProvider(vehicleProviderServiceModel);

                if (result) return this.Redirect("/");

                this.ViewData["error"] = ControllerConstants.PartProviderErrorMessage;
                return this.View("Provider/Create", partProviderBindingModel);
            }
            this.ViewData["error"] = ControllerConstants.InputErrorMessage;
            return this.View("Provider/Create", partProviderBindingModel);
        }


        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(this.View);
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(PartCreateBindingModel partCreateBindingModel)
        {
            if (ModelState.IsValid)
            {
                PartServiceModel partServiceModel = AutoMapper.Mapper.Map<PartServiceModel>(partCreateBindingModel);
                var result = await _partService.Create(partServiceModel);

                if (result) return this.Redirect("/");

                this.ViewData["error"] = ControllerConstants.PartErrorMessage;
                return this.View(partCreateBindingModel);
            }
            this.ViewData["error"] = ControllerConstants.InputErrorMessage;
            return this.View(partCreateBindingModel);
        }

        [HttpPost(Name = "AddStock")]
        public async Task<IActionResult> AddStock(PartAddStockBindingModel partAddStockBinding)
        {
            if (ModelState.IsValid)
            {
                var result = await _partService.AddStock(partAddStockBinding.Name, partAddStockBinding.Quantity);

                if (result == false)
                {
                    this.ViewData["error"] = ControllerConstants.PartAddStockErrorMessage;
                    return this.Redirect($"/Part/Details?name={partAddStockBinding.Name}");
                }
                return this.Redirect($"/Part/Details?name={partAddStockBinding.Name}");
            }
            this.ViewData["error"] = ControllerConstants.InputErrorMessage;
            return this.Redirect($"/Part/Details?name={partAddStockBinding.Name}");
        }

        public async Task<IActionResult> Delete(string name)
        {
            await _partService.DeletePart(name);
            return RedirectToAction("All");
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(string name)
        {
            return await Task.Run((() =>
                 this.View(_partService.GetPartByName(name).Result.To<PartEditViewModel>())));
        }

        [HttpPost(Name = "Edit")]
        public async Task<IActionResult> Edit(PartEditBindingModel partEditBindingModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _partService.EditPart(partEditBindingModel.To<PartServiceModel>());

                if (result) return this.Redirect($"/Part/Details?name={partEditBindingModel.Name}");

                this.ViewData["error"] = ControllerConstants.PartEditErrorMessage;
                return this.RedirectToAction("Edit", partEditBindingModel);
            }

            this.ViewData["error"] = ControllerConstants.InputErrorMessage;
            return this.RedirectToAction("Edit", partEditBindingModel);
        }
    }
}