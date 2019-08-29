using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mdms.Data.Models;
using MDMS.GlobalConstants;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Repair.Add;
using MDMS.Web.ViewModels.Part.All;
using MDMS.Web.ViewModels.Part.Details;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Web.Controllers
{
    public class PartController : UserController
    {
        private readonly IPartService _partService;
        private readonly IRepairService _repairService;
        private readonly UserManager<MdmsUser> _userManager;

        public PartController(IPartService partService, IRepairService repairService, UserManager<MdmsUser> userManager)
        {
            _partService = partService;
            _repairService = repairService;
            _userManager = userManager;
        }

        [HttpGet(Name = "All")]
        public async Task<IActionResult> All([FromQuery]string criteria = null)
        {
            if (criteria == null) criteria = ServiceConstants.PartOrderName;
            
            var parts = await Task.Run(() => _partService.GetAllParts(criteria).To<PartAllViewModel>().ToList());

            this.ViewData["criteria"] = criteria.Replace("+", " ");
            if ((string)ViewData["criteria"] != ServiceConstants.PartOrderByPriceAscending &&
                (string)ViewData["criteria"] != ServiceConstants.PartOrderByPriceDescending &&
                (string)ViewData["criteria"] != ServiceConstants.PartOrderByStockAscending &&
                (string)ViewData["criteria"] != ServiceConstants.PartOrderByStockDescending &&
                (string)ViewData["criteria"] != ServiceConstants.PartOrderByUsedCountAscending &&
                (string)ViewData["criteria"] != ServiceConstants.PartOrderByUsedCountDescending )
            {
                this.ViewData["criteria"] = ServiceConstants.PartOrderName;
            }
            return this.View(parts);
        }

        [HttpGet(Name = "AddParts")]
        public async Task<IActionResult> AddParts([FromQuery]string criteria = null)
        {
            if (criteria == null) criteria = ServiceConstants.PartOrderName;

            var listOfParts = await _partService.GetAllParts(criteria).To<InternalRepairRepairPartBindingModel>().ToListAsync();
            var  name = _repairService.GetActiveRepair(_userManager.GetUserId(User)).Result.Name;
            
            foreach (var part in listOfParts)
            {
                part.RepairName = name;
            }
            return View(listOfParts);
        }

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(string name)
        {
            try
            {
                var part =  _partService.GetPartByName(name).Result.To<PartDetailsViewModel>();
                return View(await Task.Run((() => part)));
            }
            catch (AggregateException e)
            {
                //TODO Refactor
                Console.WriteLine(e.Message);
            }
            return RedirectToAction("All");
        }
            


        [HttpPost(Name = "AddParts")]
        public async Task<IActionResult> AddParts(List<InternalRepairRepairPartBindingModel> internalRepairAddPartsBindingModel)
        {
            if (!ModelState.IsValid)
            {
                this.ViewData["error"] = ControllerConstants.InputErrorMessage;
                return this.View(internalRepairAddPartsBindingModel);
            }
            if (!internalRepairAddPartsBindingModel.Any(x => x.Quantity > 0))
            {
                this.ViewData["error"] = ControllerConstants.PartsAddErrorMessage;
                return this.View(internalRepairAddPartsBindingModel);
            }

            var internalRepairId = _repairService.GetInternalRepairIdByName(internalRepairAddPartsBindingModel[0].RepairName).Result;
            var allPartsIds = _partService.GetAllParts(null).ToList();

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