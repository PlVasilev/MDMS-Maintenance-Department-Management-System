using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mdms.Data.Models;
using MDMS.Services;
using MDMS.Services.Models;
using Microsoft.AspNetCore.Mvc;
using MDMS.Web.Models;
using MDMS.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Web.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
