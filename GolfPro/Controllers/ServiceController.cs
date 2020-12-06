using GolfPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfPro.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Member
        GolfProEntities golfProEntities = new GolfProEntities();
        public ActionResult allServices()
        {
            return View(golfProEntities.service_Setting.ToList());
        }

        public ActionResult viewServices()
        {
            return View(golfProEntities.service_Setting.ToList());
        }

        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        public ActionResult Create(service_Setting service_Setting)
        {
            if (!ModelState.IsValid)
                return View();
            golfProEntities.service_Setting.Add(service_Setting);
            golfProEntities.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("allServices");

        }

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {

            var IdToEdit = (from m in golfProEntities.service_Setting where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Member/Edit/5
        [HttpPost]
        public ActionResult Edit(service_Setting service_Setting)
        {

            var orignalRecord = (from m in golfProEntities.service_Setting where m.id == service_Setting.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            golfProEntities.Entry(orignalRecord).CurrentValues.SetValues(service_Setting);
      
            golfProEntities.SaveChanges();
            return RedirectToAction("allServices");
        }

        // GET: Member/Delete/5
        public ActionResult Delete(service_Setting service_Setting)
        {
            var d = golfProEntities.service_Setting.Where(x => x.id == service_Setting.id).FirstOrDefault();
            golfProEntities.service_Setting.Remove(d);
            golfProEntities.SaveChanges();
            return RedirectToAction("allServices");
        }



        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
