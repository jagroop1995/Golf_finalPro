using GolfPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfPro.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        GolfProEntities golfProEntities = new GolfProEntities();
        public ActionResult RegisteredMember()
        {
            return View(golfProEntities.member_Setting.ToList());
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
        public ActionResult Create(member_Setting member_Setting)
        {
            if (!ModelState.IsValid)
                return View();
            golfProEntities.member_Setting.Add(member_Setting);
            golfProEntities.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("Create");

        }

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {

            var IdToEdit = (from m in golfProEntities.member_Setting where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Member/Edit/5
        [HttpPost]
        public ActionResult Edit(member_Setting member_Setting)
        {

            var orignalRecord = (from m in golfProEntities.member_Setting where m.id == member_Setting.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            golfProEntities.Entry(orignalRecord).CurrentValues.SetValues(member_Setting);

            golfProEntities.SaveChanges();
            return RedirectToAction("RegisteredMember");
        }

        // GET: Member/Delete/5
        public ActionResult Delete(member_Setting member_Setting)
        {
            var d = golfProEntities.member_Setting.Where(x => x.id == member_Setting.id).FirstOrDefault();
            golfProEntities.member_Setting.Remove(d);
            golfProEntities.SaveChanges();
            return RedirectToAction("RegisteredMember");
        }

        // POST: Member/Delete/5
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
