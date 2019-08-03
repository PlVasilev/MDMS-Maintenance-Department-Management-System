using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Controllers
{
    public class GuestController : Controller
    {
        [Authorize(Roles = "Guest")]
        public abstract class UserController : Controller
        {
        }
    }
}