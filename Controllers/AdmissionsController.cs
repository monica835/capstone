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
    public class AdmissionsController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: tblAdmissions
        public ActionResult Index()
        {
            return View(db.tblAdmissions.ToList());
        }

        // GET: tblAdmissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdmission tblAdmission = db.tblAdmissions.Find(id);
            if (tblAdmission == null)
            {
                return HttpNotFound();
            }
            return View(tblAdmission);
        }

        // GET: tblAdmissions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblAdmissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAdmission,IDResident,AdmissionDate,TerminationDate,TreatmentFee,IsActive,Notes,TotalBilling,TotalPaid,OverallBalance,StopTFBilling,Status,IDRank,Phase")] tblAdmission tblAdmission)
        {
            if (ModelState.IsValid)
            {
                db.tblAdmissions.Add(tblAdmission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAdmission);
        }

        // GET: tblAdmissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdmission tblAdmission = db.tblAdmissions.Find(id);
            if (tblAdmission == null)
            {
                return HttpNotFound();
            }
            return View(tblAdmission);
        }

        // POST: tblAdmissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAdmission,IDResident,AdmissionDate,TerminationDate,TreatmentFee,IsActive,Notes,TotalBilling,TotalPaid,OverallBalance,StopTFBilling,Status,IDRank,Phase")] tblAdmission tblAdmission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAdmission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAdmission);
        }

        // GET: tblAdmissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdmission tblAdmission = db.tblAdmissions.Find(id);
            if (tblAdmission == null)
            {
                return HttpNotFound();
            }
            return View(tblAdmission);
        }

        // POST: tblAdmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAdmission tblAdmission = db.tblAdmissions.Find(id);
            db.tblAdmissions.Remove(tblAdmission);
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
