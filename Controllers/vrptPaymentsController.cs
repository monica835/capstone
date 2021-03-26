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
    public class vrptPaymentsController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: vrptPayments
        public ActionResult Index()
        {
            return View(db.vrptPayments.ToList());
        }

        // GET: vrptPayments/Details/5
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

        // GET: vrptPayments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vrptPayments/Create
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

        // GET: vrptPayments/Edit/5
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

        // POST: vrptPayments/Edit/5
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

        // GET: vrptPayments/Delete/5
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

        // POST: vrptPayments/Delete/5
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
