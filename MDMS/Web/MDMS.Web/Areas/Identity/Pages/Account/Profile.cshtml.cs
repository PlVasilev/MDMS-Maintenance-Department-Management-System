using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Data;
using MDMS.Data.Migrations;
using Mdms.Data.Models;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Web.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "Guest")]
    public class ProfileModel : PageModel, IMapFrom<MdmsUser>
    {
        private readonly UserManager<MdmsUser> _userManager;
        private readonly IUserService _userService;

        public ProfileModel(UserManager<MdmsUser> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal AdditionalOnHourPayment { get; set; }
        public bool IsAuthorized { get; set; }
        public List<MonthlySalaryViewModel> Salaries { get; set; } = new List<MonthlySalaryViewModel>();
        public List<InternalRepairViewModel> InternalRepairs { get; set; } = new List<InternalRepairViewModel>();
        public List<ExternalRepairViewModel> ExternalRepairs { get; set; } = new List<ExternalRepairViewModel>();


        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }


        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return LocalRedirect("/");
            }

            MDMSUserServiceModel user = _userService.GetAllUsers()
                .Include(x => x.Salaries)
                .Include(x => x.ExternalRepairs)
                .Include(x => x.InternalRepairs)
                .SingleOrDefault(x => x.Id == _userManager.GetUserId(User)).To<MDMSUserServiceModel>();
            var user1 = await Task.Run((() => _userManager.GetUserAsync(User).Result.To<MDMSUserServiceModel>()));

            FirstName = user.FirstName;
            LastName = user.LastName;
            BaseSalary = user.BaseSalary;
            AdditionalOnHourPayment = user.AdditionalOnHourPayment;
            IsAuthorized = user.IsAuthorized;

            foreach (var salary in user.Salaries) Salaries.Add(salary.To<MonthlySalaryViewModel>());
            foreach (var intRep in user.InternalRepairs) InternalRepairs.Add(intRep.To<InternalRepairViewModel>());
            foreach (var extRep in user.ExternalRepairs) ExternalRepairs.Add(extRep.To<ExternalRepairViewModel>());
            

            returnUrl = returnUrl ?? Url.Content("~/");

            ReturnUrl = returnUrl;

            return Page();
        }
    }

    public class ExternalRepairViewModel : IMapFrom<ExternalRepairServiceModel>
    {
        public string Name { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime? FinishedOn { get; set; }
    }

    public class InternalRepairViewModel : IMapFrom<InternalRepairServiceModel>
    {
        public string Name { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime? FinishedOn { get; set; }
    }

    public class MonthlySalaryViewModel : IMapFrom<MonthlySalaryServiceModel>
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public double HoursWorked { get; set; }
        public decimal AdditionalOnHourPayment { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal TotalSalary { get; set; }
    }
}