﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult ErrorMessage()
        {

            return View();
        }

        public ActionResult WrongLoginOrPassword()
        {
            return View();
        }
    }
}