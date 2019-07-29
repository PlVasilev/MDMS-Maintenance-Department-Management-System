﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.Controllers
{
    [Authorize(Roles = "User")]
    public abstract class UserController : Controller
    {
    }

}