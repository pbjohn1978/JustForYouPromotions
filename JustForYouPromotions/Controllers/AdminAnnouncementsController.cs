using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustForYouPromotions.Models;

namespace JustForYouPromotions.Controllers
{
    public class AdminAnnouncementsController : Controller
    {
        // GET: AdminAnnouncements
        public ActionResult Index()
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");

            List<Announcement> allAnnounce = HelperDB.GetMeAllTheAnnouncmentsPweez();
            ViewBag.allAnn = allAnnounce;

            return View();
        }
    }
}