using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustForYouPromotions.Models
{
    public class ContactForm
    {
        public string Name { get; set; }

        public string FromEmailAddress { get; set; }

        public string EmailSubject { get; set; }

        public string EmailBody { get; set; }
    }
}