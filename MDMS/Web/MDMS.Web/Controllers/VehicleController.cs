using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
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
        public async Task<IActionResult> All()
        {
            List<VehicleAllViewModel> allViewModels = new List<VehicleAllViewModel>();
            List<VehicleServiceModel> allVehicleServiceModels = await _vehicleService.GetAllVehicles().ToListAsync();
            foreach (var model in allVehicleServiceModels)
            {
                VehicleAllViewModel allViewModel = AutoMapper.Mapper.Map<VehicleAllViewModel>(model);
                allViewModels.Add(allViewModel);
            }
            return this.View(allViewModels);
        }

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(string name)
        {
            var vehicleDetails = AutoMapper.Mapper.Map<VehicleDetailsViewModel>(await _vehicleService.GetVehicleByName(name));

            return this.View(vehicleDetails);
        }
    }
}