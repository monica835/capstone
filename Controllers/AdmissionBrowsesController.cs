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
    public class AdmissionBrowsesController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: AdmissionBrowses
        public ActionResult Index()
        {
            return View(db.vAdmissionBrowses.ToList());
        }

        // GET: AdmissionBrowses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vAdmissionBrowse vAdmissionBrowse = db.vAdmissionBrowses.Find(id);
            if (vAdmissionBrowse == null)
            {
                return HttpNotFound();
            }
            return View(vAdmissionBrowse);
        }

        // GET: AdmissionBrowses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmissionBrowses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAdmission,IDResident,Resident,Nickname,AdmissionDate,TerminationDate,TreatmentFee,TotalBilling,TotalPaid,OverallBalance,IsActive,LastPaymentInfo,StopTFBilling,rank,Phase")] vAdmissionBrowse vAdmissionBrowse)
        {
            if (ModelState.IsValid)
            {
                db.vAdmissionBrowses.Add(vAdmissionBrowse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vAdmissionBrowse);
        }

        // GET: AdmissionBrowses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vAdmissionBrowse vAdmissionBrowse = db.vAdmissionBrowses.Find(id);
            if (vAdmissionBrowse == null)
            {
                return HttpNotFound();
            }
            return View(vAdmissionBrowse);
        }

        // POST: AdmissionBrowses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAdmission,IDResident,Resident,Nickname,AdmissionDate,TerminationDate,TreatmentFee,TotalBilling,TotalPaid,OverallBalance,IsActive,LastPaymentInfo,StopTFBilling,rank,Phase")] vAdmissionBrowse vAdmissionBrowse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vAdmissionBrowse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vAdmissionBrowse);
        }

        // GET: AdmissionBrowses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vAdmissionBrowse vAdmissionBrowse = db.vAdmissionBrowses.Find(id);
            if (vAdmissionBrowse == null)
            {
                return HttpNotFound();
            }
            return View(vAdmissionBrowse);
        }

        // POST: AdmissionBrowses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vAdmissionBrowse vAdmissionBrowse = db.vAdmissionBrowses.Find(id);
            db.vAdmissionBrowses.Remove(vAdmissionBrowse);
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
