using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Mdms.Data.Models;
using MDMS.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MDMS.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<MdmsUser> _signInManager;
        private readonly IUserService _userService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<MdmsUser> _userManager;

        public RegisterModel(
            UserManager<MdmsUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<MdmsUser> signInManager, 
            IUserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "LastName")]
            public string LastName { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                return LocalRedirect("/");
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            await Task.Run(() => ReturnUrl = returnUrl);

            ReturnUrl = returnUrl;

            return Page();

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
      

            returnUrl = "~/Identity/Account/Login";
            if (ModelState.IsValid)
            {
                var isAdmin = _userManager.Users.Count() == 1;
                var user = new MdmsUser { UserName = Input.Username,
                    Email = Input.Email,
                    IsAuthorized = false,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    Name = Input.FirstName+"-"+Input.LastName
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (isAdmin)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                        await _userManager.AddToRoleAsync(user, "User");
                        await _userManager.AddToRoleAsync(user, "Guest");
                        user.IsAuthorized = true;
                        await _userManager.UpdateAsync(user);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Guest");
                    }

                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }
    }
}
