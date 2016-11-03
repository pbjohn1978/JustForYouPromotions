using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JustForYouPromotions.Models
{
    public class SiteMember
    {
        public int UserID { get; set; }

        [Required]
        public string UserFName { get; set; }

        [Required]
        public string UserLName { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required]
        public bool UserEmailUpdates { get; set; }

        [Required]
        public int UserAccess { get; set; }
    }
}