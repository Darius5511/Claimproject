using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using capstoneproject.Models;


namespace capstoneproject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                string toAddress = "dariuscrawford65@gmail.com";
                string subject = $"Grade 4 Grades{model.FromName}";
                string body = $@"Contact Name: {model.FromName}
Contact Email: {model.FromEmail}
 
Message Body:
---------------------------------------
{model.Body}";
                Emailsender.Send(toAddress, subject, body);
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public ActionResult Hazelwood()
        {
            ViewBag.Message = "Your Hazelwood page.";

            return View();
        }
        public ActionResult Riverview()
        {
            ViewBag.Message = "Your Riverview page.";

            return View();
        }
        public ActionResult McCluer()
        {
            ViewBag.Message = "Your McCluer page.";

            return View();
        }
        
    }
}