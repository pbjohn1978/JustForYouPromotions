using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustForYouPromotions.Models;
using SendGrid;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace JustForYouPromotions.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactForm cm)
        {
            //TODO: send an email here... huff...


            return View();
            RedirectToAction("Index", "Success");
        }
    }
}