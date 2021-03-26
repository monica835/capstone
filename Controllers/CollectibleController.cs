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
    public class CollectibleController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: Collectible
        public ActionResult Index()
        {
            return View(db.vrptCollectibles.ToList());
        }

        // GET: Collectible/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrptCollectible vrptCollectible = db.vrptCollectibles.Find(id);
            if (vrptCollectible == null)
            {
                return HttpNotFound();
            }
            return View(vrptCollectible);
        }

        // GET: Collectible/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Collectible/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAdmission,IDResident,Resident,AdmissionDate,TerminationDate,TreatmentFee,TotalBilling,TotalPaid,OverallBalance,IsActive,LastPaymentInfo")] vrptCollectible vrptCollectible)
        {
            if (ModelState.IsValid)
            {
                db.vrptCollectibles.Add(vrptCollectible);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrptCollectible);
        }

        // GET: Collectible/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrptCollectible vrptCollectible = db.vrptCollectibles.Find(id);
            if (vrptCollectible == null)
            {
                return HttpNotFound();
            }
            return View(vrptCollectible);
        }

        // POST: Collectible/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAdmission,IDResident,Resident,AdmissionDate,TerminationDate,TreatmentFee,TotalBilling,TotalPaid,OverallBalance,IsActive,LastPaymentInfo")] vrptCollectible vrptCollectible)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vrptCollectible).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vrptCollectible);
        }

        // GET: Collectible/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrptCollectible vrptCollectible = db.vrptCollectibles.Find(id);
            if (vrptCollectible == null)
            {
                return HttpNotFound();
            }
            return View(vrptCollectible);
        }

        // POST: Collectible/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vrptCollectible vrptCollectible = db.vrptCollectibles.Find(id);
            db.vrptCollectibles.Remove(vrptCollectible);
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
