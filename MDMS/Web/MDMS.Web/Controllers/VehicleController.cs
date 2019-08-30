using System;
using System.Linq;
using System.Threading.Tasks;
using Mdms.Data.Models;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Web.ViewModels.Vehicle.All;
using MDMS.Web.ViewModels.Vehicle.Details;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Controllers
{
    public class VehicleController : UserController
    {
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<MdmsUser> _userManager;

        public VehicleController(IVehicleService vehicleService, UserManager<MdmsUser> userManager)
        {
            _vehicleService = vehicleService;
            _userManager = userManager;
        }

        [HttpGet(Name = "All")]
        public async Task<IActionResult> All() =>
            await Task.Run(() => this.View(_vehicleService.GetAllVehicles().To<VehicleAllViewModel>().ToList()));


        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(string name)
        {

            var user = await _userManager.GetUserAsync(User);
            var vehicleDetails = _vehicleService.GetVehicleByName(name).Result.To<VehicleDetailsViewModel>();
            vehicleDetails.MDMSUserServiceModelIsRepairing = user.IsRepairing;
            return this.View(vehicleDetails);
        }
    }
}