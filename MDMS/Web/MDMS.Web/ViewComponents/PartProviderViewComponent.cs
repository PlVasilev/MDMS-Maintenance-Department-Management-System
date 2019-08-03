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
    public class PartProviderViewComponent : ViewComponent
    {
        private readonly IPartService _partService;

        public PartProviderViewComponent(IPartService partService)
        {
            _partService = partService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vehicleCreateVehicleProviderViewModels = await _partService.GetAllPartProviders()
                .OrderBy(vt => vt.Name)
                .Select(vt => new PartProviderViewComponentViewModel() { Name = vt.Name })
                .ToListAsync();

            return View(vehicleCreateVehicleProviderViewModels);
        }
    }
}
