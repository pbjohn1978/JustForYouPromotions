using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustForYouPromotions.Models
{
    public static class AnnouncementValidator
    {


        public static int IsValidAnnouncement(Announcement an)
        {
            if (an.AnnouncementName == null || an.AnnouncementDescription == null)
                return 2;
            //TODO: validation code here... and stuff...
            if (!HelperDB.PutAnnouncementInDB(an))
                return 1;
            return 0;
        }
    }
}