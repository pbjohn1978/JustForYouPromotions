using JustForYouPromotions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustForYouPromotions.Controllers
{
    public class DeleteAnnouncementController : Controller
    {
        // GET: DeleteAnnouncement
        public ActionResult Index(int annID)
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");

            //delete Announcement here... 
            bool result = HelperDB.DeleteAnnouncement(annID);
            if (result)
                ViewBag.result = "the Announcement has been deleted";
            else
                ViewBag.result = "there was an issue... the Annoucement has not been deleted";

            return View();
        }
    }
}