using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustForYouPromotions.Models;

namespace JustForYouPromotions.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Register
        [HttpPost]
        public ActionResult Index(RegisterViewModel nuser)
        {
            try
            {
                SiteMember sm = new SiteMember();
                sm.UserAccess = 1;
                sm.UserEmail = nuser.UserEmail;
                sm.UserEmailUpdates = nuser.UserEmailUpdates;
                sm.UserFName = nuser.UserFirstName;
                sm.UserLName = nuser.UserLastName;
                sm.UserPassword = nuser.Password;
                if (!HelperDB.AddNewUser(sm))
                    return RedirectToAction("IndexErrorDB", "Error");
                return View();
            }
            catch
            {
                return RedirectToAction("IndexCatchAll", "Error");
            }
        }
    }
}