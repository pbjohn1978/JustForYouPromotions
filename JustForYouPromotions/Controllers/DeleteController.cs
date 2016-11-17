using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustForYouPromotions.Models;

namespace JustForYouPromotions.Controllers
{
    public class DeleteController : Controller
    {
        // GET: Delete
        public ActionResult Index(int UserID)
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");


            //delete user here... 
            bool result = HelperDB.DeleteMe(UserID);
            if (result)
                ViewBag.result = "the user has been deleted";
            else
                ViewBag.result = "there was an issue... the user has not been deleted";

            return View();
        }
    }
}