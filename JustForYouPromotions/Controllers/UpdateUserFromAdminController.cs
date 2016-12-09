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
                if (sm.UserAccess > 2 && !SessionHelper.IsSuperAdminSession())
                    sm.UserAccess = 2;
                if (sm.UserAccess == 0)
                    sm.UserAccess = tempUserData.UserAccess;
                sm.UserEmailUpdates = tempUserData.UserEmailUpdates;
                
                HelperDB.DeleteEmailAndUserNameForValidation(sm.UserID);

                RegisterViewModel user = new RegisterViewModel();
                user.UserFirstName = sm.UserFName;
                user.UserLastName = sm.UserLName;
                user.UserAccessName = sm.UserAccessName;
                user.UserEmail = sm.UserEmail;
                user.Password = sm.UserPassword;
                user.ConfirmPassword = sm.UserPassword;
                user.UserEmailUpdates = sm.UserEmailUpdates;
                user.UserID = sm.UserID;

                int validationResult = ValidatorClass.IsValidUser(user);
                
                if (validationResult == 0)
                {
                    if (!HelperDB.UpdateUserInDB(sm))
                    {
                        HelperDB.UpdateUserInDB(tempUserData);
                        return RedirectToAction("IndexErrorDB", "Error");
                    }
                    return RedirectToAction("Index", "Success");
                }
                else if (validationResult == 1)
                {
                    HelperDB.UpdateUserInDB(tempUserData);
                    return RedirectToAction("UserNameTaken", "Error");
                }
                else if (validationResult == 3)
                {
                    HelperDB.UpdateUserInDB(tempUserData);
                    return RedirectToAction("EmailTaken", "Error");
                }
                HelperDB.UpdateUserInDB(tempUserData);
                return RedirectToAction("IndexCatchAll", "Error");
            }
            catch
            {
                return RedirectToAction("IndexCatchAll", "Error");
            }
        }
    }
}