using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustForYouPromotions.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult IndexErrorDB()
        {
            return View();
        }

        public ActionResult IndexCatchAll()
        {
            return View();
        }

        public ActionResult UserNameTaken()
        {
            return View();
        }

        public ActionResult EmailTaken()
        {
            return View();
        }

        public ActionResult PasswordsDontMatch()
        {
            return View();
        }
    }
}