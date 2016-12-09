using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustForYouPromotions.Models
{
    public class SessionHelper
    {
        public static bool IsMemberLoggedIn()
        {
            if (HttpContext.Current.Session["memid"] == null)
                return false;
            return true;
        }

        public static Models.SiteMember GetMember()
        {
            int memID = Convert.ToInt32(HttpContext.Current.Session["memid"]);
            SiteMember mem = HelperDB.getMember(memID);
            return mem;
        }

        public static bool IsAdminSession()
        {
            if (HttpContext.Current.Session["memid"] != null)
            {
                int memID = Convert.ToInt32(HttpContext.Current.Session["memid"]);
                SiteMember mem = HelperDB.getMember(memID);
                if (mem.UserAccess > 1)
                    return true;
            }
            return false;
        }

        public static bool IsSuperAdminSession()
        {
            if (HttpContext.Current.Session["memid"] != null)
            {
                int memID = Convert.ToInt32(HttpContext.Current.Session["memid"]);
                SiteMember mem = HelperDB.getMember(memID);
                if (mem.UserAccess > 2)
                    return true;
            }
            return false;
        }
    }
}