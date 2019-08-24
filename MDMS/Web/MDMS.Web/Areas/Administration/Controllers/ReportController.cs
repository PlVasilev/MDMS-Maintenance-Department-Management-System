using System.Threading.Tasks;
using MDMS.Data;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Report.Create;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Areas.Administration.Controllers
{
    public class ReportController : AdminController
    {
        private readonly IReportService _reportService;


        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            ReportCreateBindingModel reportCreateBindingModel = new ReportCreateBindingModel();
            await Task.Run((() => { }));
            return View(reportCreateBindingModel);
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(ReportCreateBindingModel reportCreateBindingModel)
        {
            if (!ModelState.IsValid) return View(reportCreateBindingModel);

            var result = await _reportService.CreateCustomReport(reportCreateBindingModel.To<ReportServiceModel>());
            if (!result)
            {
                this.ViewData["error"] = "Report for those months already Exists.";
                return View(reportCreateBindingModel);
            }
            return Redirect("/");
        }



    }
}