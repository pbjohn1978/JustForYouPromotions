using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustForYouPromotions.Models;

namespace JustForYouPromotions.Controllers
{
    public class AdminProductsController : Controller
    {
        // GET: AdminProducts
        public ActionResult Index()
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");

            ViewBag.prods = HelperDB.GetAllProductsNowBot();

            return View();
        }
    }
}