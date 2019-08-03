using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MDMS.Web.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "Guest")]
    public class ProfileModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}