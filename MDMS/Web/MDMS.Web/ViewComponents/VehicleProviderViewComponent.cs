using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Web.ViewModels;
using MDMS.Web.ViewModels.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Web.ViewComponents
{
    public class VehicleProviderViewComponent : ViewComponent
    {
        private readonly IVehicleService _vehicleService;

        public VehicleProviderViewComponent(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vehicleCreateVehicleProviderViewModels = await _vehicleService.GetAllVehicleProviders()
                .OrderBy(vt => vt.Name)
                .Select(vt => new VehicleProviderViewComponentViewModel() { Name = vt.Name })
                .ToListAsync();

            return View(vehicleCreateVehicleProviderViewModels);
        }
    }
}
