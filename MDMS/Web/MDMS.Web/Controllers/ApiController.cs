using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Web.BindingModels.Repair.Active;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IRepairService _repairService;

        public ApiController(IRepairService repairService)
        {
            _repairService = repairService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "EditExternalDetails")]
        [Route("EditExternalDetails")]
        public async Task<IActionResult> EditExternalDetails(ExternalRepairActiveEditDescriptionBindingModel externalRepairActiveEditDescriptionBindingModel)
        {
             await _repairService.EditExternalRepairDescription(externalRepairActiveEditDescriptionBindingModel.Id,
                externalRepairActiveEditDescriptionBindingModel.Description);
             return Ok();
        }
    }
}