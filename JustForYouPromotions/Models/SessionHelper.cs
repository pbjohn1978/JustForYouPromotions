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
            SiteMember mem = HelperDB.getMember((int)HttpContext.Current.Session["memid"]);
            return mem;
        }

        //public static bool IsAdminSession()
        //{
        //    if (HttpContext.Current.Session["MemberName"] != null)
        //    {
        //        if (HelperDB.GetMember(HttpContext.Current.Session["memid"].ToString()).AccessLevel > 1)
        //            return true;
        //    }
        //    return false;
        //}
    }
}