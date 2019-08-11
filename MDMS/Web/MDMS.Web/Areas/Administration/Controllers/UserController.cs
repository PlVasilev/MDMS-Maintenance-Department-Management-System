using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mdms.Data.Models;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.BindingModels.User.Payment;
using MDMS.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Areas.Administration.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService _userService;
        private readonly UserManager<MdmsUser> _userManager;

        public UserController(IUserService userService, UserManager<MdmsUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<IActionResult> All() => await Task.Run(() => View(_userService.GetAllUsers().To<MDMSUserAllViewModel>().ToList()));

        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteUser(id);
            return RedirectToAction("All");
        }

        public async Task<IActionResult> Restore(string id)
        {
            await _userService.RestoreUser(id);
            return RedirectToAction("All");
        }

        public async Task<IActionResult> Activate(string id)
        {
            await _userService.ActivateUser(id);
            return RedirectToAction("All");
        }

        public async Task<IActionResult> DeActivate(string id)
        {
            await _userService.DeActivateUser(id);
            return RedirectToAction("All");
        }

        [HttpGet]
        [Route("/Administration/User/Payment/Edit/{name?}")]
        public async Task<IActionResult> PaymentEdit(string name) => await Task.Run(() => 
            this.View("Payment/Edit", _userService.GetCurrentUserByUsername(name).Result.To<MdmsUserEditPaymentBindingModel>()));


        [HttpPost]
        [Route("/Administration/User/Payment/Edit/{id?}")]
        public async Task<IActionResult> PaymentEdit(MdmsUserEditPaymentBindingModel mdmsUserEditPaymentBindingModel)
        {
            if (ModelState.IsValid)
            {
               var result = await _userService.EditPayment(mdmsUserEditPaymentBindingModel.To<MDMSUserServiceModel>());

                if (result) return this.Redirect("/");

                this.ViewData["error"] = "There was a problem with Request.";
                return this.View("Payment/Edit", mdmsUserEditPaymentBindingModel);
            }
            return this.View("Payment/Edit", mdmsUserEditPaymentBindingModel);
        }

        [HttpGet]
        [Route("/Administration/User/Payment/AddSalary/{name?}")]
        public async Task<IActionResult> PaymentAddSalary(string name) => await Task.Run(() =>
            this.View("Payment/AddSalary", _userService.GetCurrentUserByUsername(name).Result.To<MdmsUserAddMonthlySalaryBindingModel>()));


        [HttpPost]
        [Route("/Administration/User/Payment/AddSalary/{id?}")]
        public async Task<IActionResult> PaymentAddSalary(MdmsUserAddMonthlySalaryBindingModel mdmsUserEditPaymentBindingModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.EditPayment(mdmsUserEditPaymentBindingModel.To<MDMSUserServiceModel>());

                if (result) return this.Redirect("/");

                this.ViewData["error"] = "There was a problem with Request.";
                return this.View("Payment/AddSalary", mdmsUserEditPaymentBindingModel);
            }
            return this.View("Payment/AddSalary", mdmsUserEditPaymentBindingModel);
        }
    }
}