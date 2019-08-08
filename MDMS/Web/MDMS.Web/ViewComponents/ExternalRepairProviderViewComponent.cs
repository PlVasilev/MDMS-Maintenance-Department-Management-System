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
    public class ExternalRepairProviderViewComponent : ViewComponent
    {
        private readonly IRepairService _repairService;


        public ExternalRepairProviderViewComponent(IRepairService repairService)
        {
            _repairService = repairService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var externalRepairProviders = await _repairService.GetAllExternalRepairProviders()
                .OrderBy(vt => vt.Name)
                .Select(vt => new ExternalRepairProviderViewComponentViewModel() { Name = vt.Name })
                .ToListAsync();

            return View(externalRepairProviders);
        }
    }
}
