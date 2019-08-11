using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Mdms.Data.Models;
using MDMS.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MDMS.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<MdmsUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IUserService _userService;

        public LoginModel(SignInManager<MdmsUser> signInManager, ILogger<LoginModel> logger, IUserService userService)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userService = userService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [Display(Name = "Password")]
            public string Password { get; set; }

        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                return LocalRedirect("/");
            }

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
           string returnUrl = ("~/Home/Index");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, false, lockoutOnFailure: true);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Username or Password.");
                    return Page();
                }
                var userViewModel = await _userService.GetCurrentUserByUsername(Input.Username);
                if (userViewModel.IsDeleted)
                {
                    ModelState.AddModelError(string.Empty, "The user has been Deleted.");
                    return Page();
                }
                else
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
            }
            return Page();
        }
    }
}
