using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustForYouPromotions.Models;

namespace JustForYouPromotions.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");
            List<SiteMember> members = HelperDB.getAllMembers();
            ViewBag.mems = members;
            return View();
        }
    }
}