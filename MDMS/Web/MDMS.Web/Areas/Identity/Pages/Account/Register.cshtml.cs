using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Mdms.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MDMS.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<MdmsUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<MdmsUser> _userManager;
       // private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<MdmsUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<MdmsUser> signInManager)
           // IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
           // _emailSender = emailSender;
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

        public async Task OnGetAsync(string returnUrl = null)
        {
             await Task.Run(() => ReturnUrl = returnUrl);
           
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = "~/Identity/Account/Login";
            if (ModelState.IsValid)
            {
                var isAdmin = _userManager.Users.Count() == 1;
                var user = new MdmsUser { UserName = Input.Username,
                    Email = Input.Email,
                    IsAuthorized = true,
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
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    
                    // EMAIL sender
                   //     var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                   //     var callbackUrl = Url.Page(
                   //     "/Account/ConfirmEmail",
                   //     pageHandler: null,
                   //     values: new { userId = user.Id, code = code },
                   //     protocol: Request.Scheme);
                   //
                   //     await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                   //     $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

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
