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
    public class PaymentController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: Payment
        public ActionResult Index()
        {
            return View(db.vrptPayments.ToList());
        }

        // GET: Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrptPayment vrptPayment = db.vrptPayments.Find(id);
            if (vrptPayment == null)
            {
                return HttpNotFound();
            }
            return View(vrptPayment);
        }

        // GET: Payment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPayment,Resident,IDResident,PaidDate,IDAdmission,TotalPaid,IDPaymentMethod,PaymentMethod,PayDetails,Bank,CheckNo,CheckDate,Notes,IsVerified,PostedDate")] vrptPayment vrptPayment)
        {
            if (ModelState.IsValid)
            {
                db.vrptPayments.Add(vrptPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrptPayment);
        }

        // GET: Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrptPayment vrptPayment = db.vrptPayments.Find(id);
            if (vrptPayment == null)
            {
                return HttpNotFound();
            }
            return View(vrptPayment);
        }

        // POST: Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPayment,Resident,IDResident,PaidDate,IDAdmission,TotalPaid,IDPaymentMethod,PaymentMethod,PayDetails,Bank,CheckNo,CheckDate,Notes,IsVerified,PostedDate")] vrptPayment vrptPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vrptPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vrptPayment);
        }

        // GET: Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrptPayment vrptPayment = db.vrptPayments.Find(id);
            if (vrptPayment == null)
            {
                return HttpNotFound();
            }
            return View(vrptPayment);
        }

        // POST: Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vrptPayment vrptPayment = db.vrptPayments.Find(id);
            db.vrptPayments.Remove(vrptPayment);
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
