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
        public string UserFName { get; set; }
        public string UserLName { get; set; }
        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        public bool UserEmailUpdates { get; set; }
        public int UserAccess { get; set; }
    }
}