using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustForYouPromotions.Controllers
{
    public class LogOutController : Controller
    {
        // GET: LogOut
        public ActionResult Index()
        {
            if (!Models.SessionHelper.IsMemberLoggedIn())
                return RedirectToAction("Index", "Login");
            Session.Abandon();
            return View();
        }
    }
}