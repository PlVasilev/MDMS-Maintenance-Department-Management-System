using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Repair.Add;
using MDMS.Web.ViewModels.Part;
using MDMS.Web.ViewModels.Part.All;
using MDMS.Web.ViewModels.Part.Details;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Web.Controllers
{
    public class PartController : UserController
    {
        private readonly IPartService _partService;
        private readonly IRepairService _repairService;

        public PartController(IPartService partService, IRepairService repairService)
        {
            _partService = partService;
            _repairService = repairService;
        }

        [HttpGet(Name = "All")]
        public async Task<IActionResult> All() => await Task.Run(() => this.View(_partService.GetAllParts().To<PartAllViewModel>().ToList()));

        [HttpGet(Name = "AddParts")]
        public async Task<IActionResult> AddParts(string name)
        {
            var listOfParts = await _partService.GetAllParts().To<InternalRepairRepairPartBindingModel>().ToListAsync();
            foreach (var part in listOfParts)
            {
                part.RepairName = name;
            }

            return View(listOfParts);
        }

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(string name) => await Task.Run((() =>
            View(_partService.GetPartByName(name).Result.To<PartDetailsViewModel>())));
    
        
        [HttpPost(Name = "AddParts")]
        public async Task<IActionResult> AddParts(List<InternalRepairRepairPartBindingModel> internalRepairAddPartsBindingModel)
        {
            if (!ModelState.IsValid) return this.View(internalRepairAddPartsBindingModel);
            if (!internalRepairAddPartsBindingModel.Any(x => x.Quantity > 0))
            {
                this.ViewData["error"] = "You must add at least One part!";
                return this.View(internalRepairAddPartsBindingModel);
            }

            var internalRepairId = _repairService.GetInternalRepairIdByName(internalRepairAddPartsBindingModel[0].RepairName).Result;
            var allPartsIds = _partService.GetAllParts().ToList();

            List<InternalRepairPartServiceModel> internalRepairPartServiceModels = new List<InternalRepairPartServiceModel>();

            foreach (var part in internalRepairAddPartsBindingModel.Where(x => x.Quantity > 0))
            {
                internalRepairPartServiceModels.Add(new InternalRepairPartServiceModel
                {
                    PartId = allPartsIds.SingleOrDefault(x => x.Name == part.Name)?.Id,
                    InternalRepairId = internalRepairId,
                    Quantity = part.Quantity
                });
            }

            await _repairService.AddPartsToInternalRepair(internalRepairPartServiceModels);

            return Redirect("/Repair/InternalActive");
        }
    }
}