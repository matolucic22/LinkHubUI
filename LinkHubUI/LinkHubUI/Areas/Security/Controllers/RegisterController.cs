﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Security/Register
        public ActionResult Index()
        {
            return View();
        }
    }
}