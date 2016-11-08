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
                int validationResult = ValidatorClass.IsValidUser(nuser);
                if (validationResult == 0)
                {
                    SiteMember sm = new SiteMember();
                    sm.UserAccess = 1;
                    sm.UserAccessName = nuser.UserAccessName;
                    sm.UserFName = nuser.UserFirstName;
                    sm.UserLName = nuser.UserLastName;
                    sm.UserEmail = nuser.UserEmail;
                    sm.UserEmailUpdates = nuser.UserEmailUpdates;
                    sm.UserPassword = nuser.Password;
                    if (!HelperDB.AddNewUser(sm))
                        return RedirectToAction("IndexErrorDB", "Error");
                    return View();
                }
                else if(validationResult == 1)
                {
                    return RedirectToAction("UserNameTaken", "Error");
                }
                else if (validationResult == 2)
                {
                    return RedirectToAction("PasswordsDontMatch", "Error");
                }
                else if (validationResult == 3)
                {
                    return RedirectToAction("EmailTaken", "Error");
                }
                return RedirectToAction("IndexCatchAll", "Error");
            }
            catch
            {
                return RedirectToAction("IndexCatchAll", "Error");
            }
        }
    }
}