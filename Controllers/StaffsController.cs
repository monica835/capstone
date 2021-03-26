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
    public class StaffsController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: Staffs
        public ActionResult Index()
        {
            return View(db.tblStaffs.ToList());
        }

        // GET: Staffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStaff tblStaff = db.tblStaffs.Find(id);
            if (tblStaff == null)
            {
                return HttpNotFound();
            }
            return View(tblStaff);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDStaff,Lastname,Firstname,ContactNo,DateHired,DateTerminated,Status,Notes,Username,Email,Password")] tblStaff tblStaff)
        {
            if (ModelState.IsValid)
            {
                db.tblStaffs.Add(tblStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblStaff);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStaff tblStaff = db.tblStaffs.Find(id);
            if (tblStaff == null)
            {
                return HttpNotFound();
            }
            return View(tblStaff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDStaff,Lastname,Firstname,ContactNo,DateHired,DateTerminated,Status,Notes,Username,Email,Password")] tblStaff tblStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblStaff);
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStaff tblStaff = db.tblStaffs.Find(id);
            if (tblStaff == null)
            {
                return HttpNotFound();
            }
            return View(tblStaff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStaff tblStaff = db.tblStaffs.Find(id);
            db.tblStaffs.Remove(tblStaff);
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
