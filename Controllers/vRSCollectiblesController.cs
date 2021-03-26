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
    public class vRSCollectiblesController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: vRSCollectibles
        public ActionResult Index()
        {
            return View(db.vRSCollectibles.ToList());
        }

        // GET: vRSCollectibles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vRSCollectible vRSCollectible = db.vRSCollectibles.Find(id);
            if (vRSCollectible == null)
            {
                return HttpNotFound();
            }
            return View(vRSCollectible);
        }

        // GET: vRSCollectibles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vRSCollectibles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAdmission,IDResident,Resident,AdmissionDate,TerminationDate,TreatmentFee,TotalBilling,TotalPaid,OverallBalance,IsActive,LastPaymentInfo")] vRSCollectible vRSCollectible)
        {
            if (ModelState.IsValid)
            {
                db.vRSCollectibles.Add(vRSCollectible);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vRSCollectible);
        }

        // GET: vRSCollectibles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vRSCollectible vRSCollectible = db.vRSCollectibles.Find(id);
            if (vRSCollectible == null)
            {
                return HttpNotFound();
            }
            return View(vRSCollectible);
        }

        // POST: vRSCollectibles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAdmission,IDResident,Resident,AdmissionDate,TerminationDate,TreatmentFee,TotalBilling,TotalPaid,OverallBalance,IsActive,LastPaymentInfo")] vRSCollectible vRSCollectible)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vRSCollectible).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vRSCollectible);
        }

        // GET: vRSCollectibles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vRSCollectible vRSCollectible = db.vRSCollectibles.Find(id);
            if (vRSCollectible == null)
            {
                return HttpNotFound();
            }
            return View(vRSCollectible);
        }

        // POST: vRSCollectibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vRSCollectible vRSCollectible = db.vRSCollectibles.Find(id);
            db.vRSCollectibles.Remove(vRSCollectible);
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
