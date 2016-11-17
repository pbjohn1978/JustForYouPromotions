﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustForYouPromotions.Controllers
{
    public class SuccessController : Controller
    {
        // GET: Success
        public ActionResult Index()
        {
            if (!Models.SessionHelper.IsMemberLoggedIn())
                return RedirectToAction("Index", "Login");
            return View();
        }
    }
}