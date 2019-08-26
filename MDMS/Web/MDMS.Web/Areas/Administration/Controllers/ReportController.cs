using System.Linq;
using System.Threading.Tasks;
using MDMS.Data;
using MDMS.GlobalConstants;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.Report.Create;
using MDMS.Web.ViewModels.Report.All;
using MDMS.Web.ViewModels.Report.Details;
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
            if (!ModelState.IsValid)
            {
                this.ViewData["error"] = ControllerConstants.InputErrorMessage;
                return View(reportCreateBindingModel);
            }

            var result = await _reportService.CreateCustomReport(reportCreateBindingModel.To<ReportServiceModel>());
            if (!result)
            {
                this.ViewData["error"] = ControllerConstants.ReportCreateErrorMessage;
                return View(reportCreateBindingModel);
            }
            return Redirect("/");
        }

        [HttpGet(Name = "All")]
        public async Task<IActionResult> All() => await Task.Run(() => 
            this.View(_reportService.GetAllReports().To<ReportAllViewModel>().ToList()));

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(string name) => await Task.Run(() =>
            this.View(_reportService.GetReportDetails(name).Result.To<ReportDetailsViewModel>()));

        [HttpGet(Name = "Delete")]
        public async Task<IActionResult> Delete(string name)
        {
            await _reportService.DeleteReport(name);
            return RedirectToAction("All");
        }
        


    }
}