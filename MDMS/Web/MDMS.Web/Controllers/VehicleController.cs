using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.ViewModels.Vehicle.All;
using MDMS.Web.ViewModels.Vehicle.Details;
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
        public async Task<IActionResult> All() =>
            await Task.Run(() => this.View(_vehicleService.GetAllVehicles().To<VehicleAllViewModel>().ToList()));
        

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(string name) => 
            await Task.Run(() => this.View(_vehicleService.GetVehicleByName(name).To<VehicleDetailsViewModel>()));
        
    }
}