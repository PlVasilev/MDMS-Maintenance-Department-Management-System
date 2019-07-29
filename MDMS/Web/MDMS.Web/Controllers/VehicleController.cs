using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Web.ViewModels.Vehicle.All;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Web.Controllers
{
    public class VehicleController : UserController
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet(Name = "All")]
        public async Task<IActionResult> All()
        {
            List<VehicleAllViewModel> allViewModels = await _vehicleService.GetAllVehicles().Select(v => new VehicleAllViewModel()
            {
                Id = v.Id,
                Model = v.Model,
                Make = v.Make,
                VSN = v.VSN,
                Picture = v.Picture

            }).ToListAsync();

            return this.View(allViewModels);
        }
    }
}