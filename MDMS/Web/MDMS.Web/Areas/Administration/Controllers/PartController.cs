using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Part;
using MDMS.Web.BindingModels.Vehicle;
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
               var result =  await _partService.CreatePartProvider(vehicleProviderServiceModel);

                if(result) return this.Redirect("/");

                this.ViewData["error"] = "Part provider with that name already exist.";
                return this.View("Provider/Create", partProviderBindingModel);
            }
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

                this.ViewData["error"] = "Part with that name already exist.";
                return this.View(partCreateBindingModel);
            }
            return this.View(partCreateBindingModel);
        }

    }
}