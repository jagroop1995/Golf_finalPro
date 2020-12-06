using GolfPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfPro.Controllers
{
    public class StaffMemberController : Controller
    {

       // GET: Member
        GolfProEntities golfProEntities = new GolfProEntities();
        public ActionResult RegisteredEmployee()
        {
            return View(golfProEntities.employee_Setting.ToList());
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
        public ActionResult Create(employee_Setting employee_Setting)
        {
            if (!ModelState.IsValid)
                return View();
            golfProEntities.employee_Setting.Add(employee_Setting);
            golfProEntities.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("RegisteredEmployee");

        }

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {

            var IdToEdit = (from m in golfProEntities.employee_Setting where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Member/Edit/5
        [HttpPost]
        public ActionResult Edit(employee_Setting employee_Setting)
        {

            var orignalRecord = (from m in golfProEntities.employee_Setting where m.id == employee_Setting.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            golfProEntities.Entry(orignalRecord).CurrentValues.SetValues(employee_Setting);

            golfProEntities.SaveChanges();
            return RedirectToAction("RegisteredEmployee");
        }

        // GET: Member/Delete/5
        public ActionResult Delete(employee_Setting employee_Setting)
        {
            var d = golfProEntities.employee_Setting.Where(x => x.id == employee_Setting.id).FirstOrDefault();
            golfProEntities.employee_Setting.Remove(d);
            golfProEntities.SaveChanges();
            return RedirectToAction("RegisteredEmployee");
        }

        // POST: StaffMember/Delete/5
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
