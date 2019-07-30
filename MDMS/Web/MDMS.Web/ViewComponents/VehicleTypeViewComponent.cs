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
    public class VehicleTypeViewComponent : ViewComponent
    {
        private readonly IVehicleService _vehicleService;

        public VehicleTypeViewComponent(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vehicleTypeViewComponentViewModels = await _vehicleService.GetAllVehicleTypes()
                .OrderBy(vt => vt.Name)
                .Select(vt => new VehicleTypeViewComponentViewModel(){Name = vt.Name})
                .ToListAsync();

            return View(vehicleTypeViewComponentViewModels);
        }

    }
}
