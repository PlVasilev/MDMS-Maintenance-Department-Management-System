using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Controllers
{
    [Authorize(Roles = "User")]
    public abstract class UserController : Controller
    {
    }

}