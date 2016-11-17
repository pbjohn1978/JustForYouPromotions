using JustForYouPromotions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustForYouPromotions.Controllers
{
    public class InvalidCredsController : Controller
    {

        
        // GET: InvalidCreds
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(LoginModel user)
        {

            if (ModelState.IsValid)
            {
                //validate userName and Password
                SiteMember sm = HelperDB.getUserLoggedIn(user);
                if (sm.UserAccessName == null)
                    return RedirectToAction("Index", "InvalidCreds");
                //create session for user
                Session["memid"] = sm.UserID;
                TempData["username"] = sm.UserAccessName;
                TempData["first"] = sm.UserFName;
                TempData["last"] = sm.UserLName;
                TempData["email"] = sm.UserEmail;
                TempData["e-update"] = sm.UserEmailUpdates;
                TempData["pass"] = sm.UserPassword;
                return RedirectToAction("Index", "UsersPage");
            }
            return RedirectToAction("Index", "InvalidCreds");
        }

    }
}