using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustForYouPromotions.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImgPath { get; set; }
        public string ProductThumbPath { get; set; }
        public string ProductAltText { get; set; }

    }
}