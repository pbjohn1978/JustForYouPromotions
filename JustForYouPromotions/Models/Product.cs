using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JustForYouPromotions.Models
{
    public class Product
    {   
        public int ProductID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public string ProductImgPath { get; set; }

        [Required]
        public string ProductThumbPath { get; set; }

        [Required]
        public string ProductAltText { get; set; }

    }
}