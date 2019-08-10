using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mdms.Data.Models;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MDMS.Web.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "Guest")]
    public class ProfileModel : PageModel, IMapFrom<MdmsUser>
    {
        private readonly UserManager<MdmsUser> _userManager;

        public ProfileModel(UserManager<MdmsUser> userManager)
        {
            _userManager = userManager;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal AdditionalOnHourPayment { get; set; }
        public bool IsAuthorized { get; set; } = false;
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

            var user = await Task.Run((() => _userManager.GetUserAsync(User).Result.To<MDMSUserServiceModel>()));

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
    }

    public class InternalRepairViewModel : IMapFrom<InternalRepairServiceModel>
    {
        public string Name { get; set; }
        public DateTime StartedOn { get; set; }
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