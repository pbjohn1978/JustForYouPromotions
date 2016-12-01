using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustForYouPromotions.Models;

namespace JustForYouPromotions.Controllers
{
    public class ProductPageController : Controller
    {
        // GET: ProductPage
        public ActionResult Index(int pdID)
        {
            List<Product> prods = HelperDB.GetAllProductsNowBot();
            foreach (Product i in prods)
            {
                if (i.ProductID == pdID)
                {
                    ViewBag.prod = i;
                }
            }
            return View();
        }
    }
}