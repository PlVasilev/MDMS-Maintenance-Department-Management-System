using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Areas.Administration.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> All() => await Task.Run(() => View(_userService.GetAllUsers().To<MDMSUserAllViewModel>().ToList()));

        public async Task<IActionResult> Delete(string id)
        {

            return RedirectToAction("All");
        }
    }
}