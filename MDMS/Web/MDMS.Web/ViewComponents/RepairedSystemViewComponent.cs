using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Web.ViewModels.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Web.ViewComponents
{
    public class RepairedSystemViewComponent : ViewComponent
    {
        private readonly IRepairService _repairService;

        public RepairedSystemViewComponent(IRepairService repairService)
        {
            _repairService = repairService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var repairedSystemViewComponentViewModels = await _repairService.GetAllRepairedSystems()
                .OrderBy(vt => vt.Name)
                .Select(vt => new RepairedSystemViewComponentViewModel() { Name = vt.Name })
                .ToListAsync();

            return View(repairedSystemViewComponentViewModels);
        }
    }
}
