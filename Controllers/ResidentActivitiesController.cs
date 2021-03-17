using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Icarus.Models;

namespace Icarus.Controllers
{
    public class ResidentActivitiesController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: ResidentActivities
        public ActionResult Index()
        {
            return View(db.tblResidentActivities.ToList());
        }

        // GET: ResidentActivities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblResidentActivity tblResidentActivity = db.tblResidentActivities.Find(id);
            if (tblResidentActivity == null)
            {
                return HttpNotFound();
            }
            return View(tblResidentActivity);
        }

        // GET: ResidentActivities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResidentActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDResidentActivityLog,LogDate,IDAdmission,Position,Activity,PostedBy")] tblResidentActivity tblResidentActivity)
        {
            if (ModelState.IsValid)
            {
                db.tblResidentActivities.Add(tblResidentActivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblResidentActivity);
        }

        // GET: ResidentActivities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblResidentActivity tblResidentActivity = db.tblResidentActivities.Find(id);
            if (tblResidentActivity == null)
            {
                return HttpNotFound();
            }
            return View(tblResidentActivity);
        }

        // POST: ResidentActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDResidentActivityLog,LogDate,IDAdmission,Position,Activity,PostedBy")] tblResidentActivity tblResidentActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblResidentActivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblResidentActivity);
        }

        // GET: ResidentActivities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblResidentActivity tblResidentActivity = db.tblResidentActivities.Find(id);
            if (tblResidentActivity == null)
            {
                return HttpNotFound();
            }
            return View(tblResidentActivity);
        }

        // POST: ResidentActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblResidentActivity tblResidentActivity = db.tblResidentActivities.Find(id);
            db.tblResidentActivities.Remove(tblResidentActivity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
