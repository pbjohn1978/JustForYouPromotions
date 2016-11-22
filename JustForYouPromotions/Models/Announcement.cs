using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JustForYouPromotions.Models
{
    public class Announcement
    {
        private DateTime expireDate;
        private DateTime date;

        public int AnnouncementID { get; set; }
        public string AnnouncementName { get; set; }
        public string AnnouncementDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime AnnouncementExpireDate
        {
            get { return expireDate.Date; }
            set { expireDate = value; }
        }

        public string GetExpireDate {
            get { return expireDate.Month + "/" + expireDate.Day + "/" + expireDate.Year; }
        }


        [DataType(DataType.Date)]
        public DateTime AnnouncementDate
        {
            get { return date.Date; }
            set { date = value; }
        }

        public string GetAnnounceDate {

            get { return date.Month + "/" + date.Day + "/" + date.Year; }
        }
    }
}