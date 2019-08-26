using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Controllers
{
    [Authorize(Roles = "Guest")]
    public class GuestController : Controller
    {
    }
}