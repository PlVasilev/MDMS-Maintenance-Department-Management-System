using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Repair.Add;
using MDMS.Web.ViewModels.Part;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Web.Controllers
{
    public class PartController : UserController
    {
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        [HttpGet(Name = "All")]
        public async Task<IActionResult> All() => await Task.Run(() => this.View(_partService.GetAllParts().To<PartAllViewModel>().ToList()));

        [HttpGet(Name = "AddParts")]
        public IActionResult AddParts(string name)
        {
            var listOfParts = _partService.GetAllParts().To<InternalRepairRepairPartBindingModel>().ToList();
            foreach (var part in listOfParts)
            {
                part.RepairName = name;
            }

            return View(listOfParts);
        }

        [HttpPost(Name = "AddParts")]
        public IActionResult AddParts(List<InternalRepairRepairPartBindingModel> internalRepairAddPartsBindingModel)
        {
         
            return Redirect("/");
        }

    }
}