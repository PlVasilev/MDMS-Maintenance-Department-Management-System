﻿using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Web.BindingModels.Repair.Active;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "User")]
        [HttpPost(Name = "EditInternalDetails")]
        [Route("EditInternalDetails")]
        public async Task<IActionResult> EditInternalDetails(InternalRepairActiveEditDescriptionBindingModel internalRepairActiveEditDescriptionBindingModel)
        {
            await _repairService.EditInternalRepairDescription(internalRepairActiveEditDescriptionBindingModel.Id,
                internalRepairActiveEditDescriptionBindingModel.Description);
            return Ok();
        }
    }
}