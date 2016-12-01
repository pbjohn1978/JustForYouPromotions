using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustForYouPromotions.Models;
using SendGrid;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace JustForYouPromotions.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactForm cm)
        {
            //TODO: send an email here... huff...
            // Create the email object first, then add the properties.
            var myMessage = new SendGridMessage();

            // Add the message properties.
            myMessage.From = new MailAddress(ConfigurationManager.ConnectionStrings["emailAddress"].ToString());

            // Add multiple addresses to the To field.
            string recipients = ConfigurationManager.ConnectionStrings["emailAddress"].ToString();

            myMessage.AddTo(recipients);

            myMessage.Subject = cm.EmailSubject;

            //Add the HTML and Text bodies
            myMessage.Html = $"<p>Customer Name: {cm.Name}</p><p>Subject: {cm.EmailSubject}</p><p>Customer Email: {cm.FromEmailAddress}</p><p>Customer Message: {cm.EmailBody}</p>";
            myMessage.Text = "Hello World plain text!";

            var apiKey = "";
            // create a Web transport, using API Key
            var transportWeb = new Web(apiKey);

            transportWeb.DeliverAsync(myMessage);
            
            return RedirectToAction("Index", "Success");
        }
    }
}