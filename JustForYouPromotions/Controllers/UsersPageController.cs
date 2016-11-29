using JustForYouPromotions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustForYouPromotions.Controllers
{
    public class UsersPageController : Controller
    {
        // GET: UsersPage
        public ActionResult Index()
        {
            if (!Models.SessionHelper.IsMemberLoggedIn())
                return RedirectToAction("Index", "Login");
            SiteMember mem = SessionHelper.GetMember();
            RegisterViewModel update = new RegisterViewModel();
            update.ConfirmPassword = mem.UserPassword;
            update.Password = mem.UserPassword;
            update.UserAccessName = mem.UserAccessName;
            update.UserEmail = mem.UserEmail;
            update.UserEmailUpdates = mem.UserEmailUpdates;
            update.UserFirstName = mem.UserFName;
            update.UserLastName = mem.UserLName;
            return View(update);
        }

        [HttpPost]
        public ActionResult Index(Models.RegisterViewModel nuser)
        {
            if (!Models.SessionHelper.IsMemberLoggedIn())
                return RedirectToAction("Index", "Login");
            try
            {
                if (!Models.SessionHelper.IsMemberLoggedIn())
                    return RedirectToAction("Index", "Login");
                SiteMember mem = SessionHelper.GetMember();

                if (nuser.UserAccessName == null)
                    nuser.UserAccessName = mem.UserAccessName;
                if (nuser.UserEmail == null)
                    nuser.UserEmail = mem.UserEmail;
                if (nuser.UserFirstName == null)
                    nuser.UserFirstName = mem.UserFName;
                if (nuser.UserLastName == null)
                    nuser.UserLastName = mem.UserLName;
                if (nuser.Password == null)
                    nuser.Password = mem.UserPassword;
                if (nuser.ConfirmPassword == null)
                    nuser.ConfirmPassword = mem.UserPassword;

                HelperDB.DeleteMe(mem.UserID);
                int validationResult = ValidatorClass.IsValidUser(nuser);
                if (validationResult == 0)
                {
                    SiteMember sm = new Models.SiteMember();
                    sm.UserAccess = 1;
                    sm.UserAccessName = nuser.UserAccessName;
                    sm.UserFName = nuser.UserFirstName;
                    sm.UserLName = nuser.UserLastName;
                    sm.UserEmail = nuser.UserEmail;
                    sm.UserEmailUpdates = nuser.UserEmailUpdates;
                    sm.UserPassword = nuser.Password;
                    sm.UserID = mem.UserID;
                    if (!HelperDB.AddNewUser(sm))
                    {
                        HelperDB.AddNewUser(mem);
                        return RedirectToAction("IndexErrorDB", "Error");
                    }
                    return RedirectToAction("Index", "Success");
                }
                else if (validationResult == 2)
                {
                    HelperDB.AddNewUser(mem);
                    return RedirectToAction("PasswordsDontMatch", "Error");
                }
                else if (validationResult == 1)
                {
                    HelperDB.AddNewUser(mem);
                    return RedirectToAction("UserNameTaken", "Error");
                }
                else if (validationResult == 3)
                {
                    HelperDB.AddNewUser(mem);
                    return RedirectToAction("EmailTaken", "Error");
                }
                HelperDB.AddNewUser(mem);
                return RedirectToAction("IndexCatchAll", "Error");
            }
            catch
            {
                return RedirectToAction("IndexCatchAll", "Error");
            }
        }
    }
}