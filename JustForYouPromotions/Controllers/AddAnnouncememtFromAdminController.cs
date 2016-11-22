using JustForYouPromotions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustForYouPromotions.Controllers
{
    public class AddAnnouncememtFromAdminController : Controller
    {
        // GET: AddAnnouncememtFromAdmin
        public ActionResult Index()
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpPost]
        public ActionResult Index(Announcement an)
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");
            
            int validatorResult = AnnouncementValidator.IsValidAnnouncement(an);
            if (validatorResult == 1)
            {
                return RedirectToAction("IndexProb2", "AddAnnouncememtFromAdmin");
            }
            else if (validatorResult == 2)
            {
                ViewBag.mess = "All feilds must be filled in.";
                return RedirectToAction("IndexProb", "AddAnnouncememtFromAdmin");
            }

            return RedirectToAction("Index", "Success");
        }

        public ActionResult IndexProb()
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");

            ViewBag.mess = "All feilds must be filled in.";
            return View();
        }
        [HttpPost]
        public ActionResult IndexProb(Announcement an)
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");

            int validatorResult = AnnouncementValidator.IsValidAnnouncement(an);
            if (validatorResult == 1)
            {
                return RedirectToAction("IndexProb2", "AddAnnouncememtFromAdmin");
            }
            else if (validatorResult == 2)
            {
                ViewBag.mess = "All feilds must be filled in.";
                return RedirectToAction("IndexProb", "AddAnnouncememtFromAdmin");
            }

            return RedirectToAction("Index", "Success");
        }

        public ActionResult IndexProb2()
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");

            ViewBag.mess = "Dates must be in the correct format.";
            return View();
        }

        [HttpPost]
        public ActionResult IndexProb2(Announcement an)
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");

            int validatorResult = AnnouncementValidator.IsValidAnnouncement(an);
            if (validatorResult == 1)
            {
                return RedirectToAction("IndexProb2", "AddAnnouncememtFromAdmin");
            }
            else if (validatorResult == 2)
            {
                ViewBag.mess = "All feilds must be filled in.";
                return RedirectToAction("IndexProb", "AddAnnouncememtFromAdmin");
            }

            return RedirectToAction("Index", "Success");
        }
    }
}