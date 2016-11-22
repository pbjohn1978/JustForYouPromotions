using JustForYouPromotions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace JustForYouPromotions.Controllers
{
    public class AddProductFromAdminController : Controller
    {
        // GET: AddProductFromAdmin
        public ActionResult Index()
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");

            return View();
        }
        [HttpPost]
        public ActionResult Index(ProductModel pd, HttpPostedFileBase prodPhoto)
        {
            if (!SessionHelper.IsAdminSession())
                return RedirectToAction("Index", "Login");
            
                ////one way to grab a file from an upload...
                //var file = Request.Files["prodPhoto"];

            if (prodPhoto != null && prodPhoto.ContentLength > 0)
            {
                Product p = new Product();
                //if (prodPhoto.ContentLength < 115242880)
                //{
                //    return RedirectToAction("Index", "AddProductFromAdmin");
                //}
                if (ModelState.IsValid)
                {
                    if (!(prodPhoto.ContentType == "image/jpeg" || prodPhoto.ContentType == "image/jpeg"))
                    {
                        return RedirectToAction("Index", "AddProductFromAdmin");
                    }

                    string fileName = Guid.NewGuid().ToString() + prodPhoto.FileName.Substring(prodPhoto.FileName.LastIndexOf("."));
                    p.ProductImgPath = fileName;
                    p.ProductThumbPath = fileName;
                    p.ProductAltText = pd.AltText;
                    p.CategoryID = 1;
                    p.ProductDescription = pd.ProductDesc;
                    p.ProductName = pd.ProductName;
                    string path = Path.Combine(Server.MapPath("~/images/"), fileName);
                    prodPhoto.SaveAs(path);

                    if (!HelperDB.PutProductInTheDB(p))
                        return RedirectToAction("IndexErrorDB", "Error");

                    return RedirectToAction("Index", "AdminProducts");
                }
                else
                {
                    //TODO: put in a redirct action for not all fields being filled out... 
                }
            }

            return RedirectToAction("Index", "Success");
        }
    }
}