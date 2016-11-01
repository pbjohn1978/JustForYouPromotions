using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustForYouPromotions.Models
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }
        public string AnnouncementName { get; set; }
        public string AnnouncementDescription { get; set; }
        public string AnnouncementExpireDate { get; set; }
        public string AnnouncementDate { get; set; }

    }
}