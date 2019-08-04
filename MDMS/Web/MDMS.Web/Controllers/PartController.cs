using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Services;
using MDMS.Web.ViewModels.Part;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Web.Controllers
{
    public class PartController : UserController
    {
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        [HttpGet(Name = "All")]
        public async Task<IActionResult> All()
        {
            var partAllViewModels = new List<PartAllViewModel>();
            var partAllServiceModels = await _partService.GetAllParts().ToListAsync();
            foreach (var part in partAllServiceModels)
            {
                var partAllViewModel = AutoMapper.Mapper.Map<PartAllViewModel>(part);
                partAllViewModels.Add(partAllViewModel);
            }
            return View(partAllViewModels);
        }
    }
}