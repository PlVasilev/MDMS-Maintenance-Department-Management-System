using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Areas.Administration.Controllers
{ 
    public class PartController : AdminController
    {
        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            return null;
        }
    }
}