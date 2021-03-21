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
    public class ResidentController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: Resident
        public ActionResult Index()
        {
            return View(db.tblResidents.ToList());
        }

        // GET: Resident/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblResident tblResident = db.tblResidents.Find(id);
            if (tblResident == null)
            {
                return HttpNotFound();
            }
            return View(tblResident);
        }

        // GET: Resident/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resident/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDResident,Lastname,Firstname,Middlename,Nickname,Birthdate,Age,Sex,Codep,Relationship,ContactNumber,EmailAddress")] tblResident tblResident)
        {
            if (ModelState.IsValid)
            {
                db.tblResidents.Add(tblResident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblResident);
        }

        // GET: Resident/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblResident tblResident = db.tblResidents.Find(id);
            if (tblResident == null)
            {
                return HttpNotFound();
            }
            return View(tblResident);
        }

        // POST: Resident/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDResident,Lastname,Firstname,Middlename,Nickname,Birthdate,Age,Sex,Codep,Relationship,ContactNumber,EmailAddress")] tblResident tblResident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblResident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblResident);
        }

        // GET: Resident/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblResident tblResident = db.tblResidents.Find(id);
            if (tblResident == null)
            {
                return HttpNotFound();
            }
            return View(tblResident);
        }

        // POST: Resident/Delete/5
        [HttpPost, ActionName("Resident")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblResident tblResident = db.tblResidents.Find(id);
            db.tblResidents.Remove(tblResident);
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
