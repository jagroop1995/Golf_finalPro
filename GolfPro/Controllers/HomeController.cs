using GolfPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfPro.Controllers
{
    public class HomeController : Controller
    {
        GolfProEntities golfProEntities = new GolfProEntities();

        public ActionResult viewContact()
        {
            return View(golfProEntities.contact_Setting.ToList());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult feedback()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Member/Delete/5
        public ActionResult Delete(contact_Setting contact_Setting)
        {
            var d = golfProEntities.contact_Setting.Where(x => x.id == contact_Setting.id).FirstOrDefault();
            golfProEntities.contact_Setting.Remove(d);
            golfProEntities.SaveChanges();
            return RedirectToAction("viewContact");
        }



        [HttpPost]
        public ActionResult contact_setting(contact contact)
        {
            //generate the query to check the user name or passwod
            String qry = "insert into contact_Setting(first_Name,last_Name,Email,Message) values('"+contact.firstName+"','"+contact.lastName+"','"+contact.Email+"','"+contact.Message+"')";

            Sqlconnection connection = new Sqlconnection();
            int x = connection.contactTest(qry);
            if (x == 1)
            {
                return View("feedback");
            }
            else {
                return View();
            }
         


        }
    }
}