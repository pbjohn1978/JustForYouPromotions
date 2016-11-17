using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustForYouPromotions.Models;

namespace JustForYouPromotions.Controllers
{
    public class UpdateUserFromAdminController : Controller
    {
        // GET: UpdateUserFromAdmin
        public ActionResult Index(int userid)
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");

            SiteMember member = HelperDB.getMember(userid);
            ViewBag.mem = member;
            return View();
        }

        [HttpPost]
        public ActionResult Index(SiteMember sm)
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");
            try
            {
                SiteMember tempUserData = HelperDB.getMember(sm.UserID);

                if (sm.UserAccessName == null)
                    sm.UserAccessName = tempUserData.UserAccessName;
                if (sm.UserEmail == null)
                    sm.UserEmail = tempUserData.UserEmail;
                if (sm.UserFName == null)
                    sm.UserFName = tempUserData.UserFName;
                if (sm.UserLName == null)
                    sm.UserLName = tempUserData.UserLName;
                if (sm.UserPassword == null)
                    sm.UserPassword = tempUserData.UserPassword;
                if (sm.UserAccess == 0)
                    sm.UserAccess = tempUserData.UserAccess;
                sm.UserEmailUpdates = tempUserData.UserEmailUpdates;

                int validationResult = ValidatorClass.IsValidUserUpdateFromAdmin(sm);

                if (validationResult == 0)
                {
                    if (!HelperDB.UpdateUserInDB(sm))
                        return RedirectToAction("IndexErrorDB", "Error");
                    return RedirectToAction("Index", "Success");
                }
                else if (validationResult == 1)
                {
                    return RedirectToAction("UserNameTaken", "Error");
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