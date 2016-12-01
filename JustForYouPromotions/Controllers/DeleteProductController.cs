using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustForYouPromotions.Models;

namespace JustForYouPromotions.Controllers
{
    public class DeleteProductController : Controller
    {
        // GET: DeleteProduct
        public ActionResult Index(int pdID)
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");

            bool result = HelperDB.DeleteProduct(pdID);
            if (result)
                ViewBag.result = "the product has been deleted";
            else
                ViewBag.result = "there was an issue... the product has not been deleted";

            return View();
        }
    }
}