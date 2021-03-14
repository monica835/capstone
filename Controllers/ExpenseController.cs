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
    public class ExpenseController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: Expense
        public ActionResult Index()
        {
            return View(db.vrptExpenses.ToList());
        }

        // GET: Expense/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrptExpens vrptExpens = db.vrptExpenses.Find(id);
            if (vrptExpens == null)
            {
                return HttpNotFound();
            }
            return View(vrptExpens);
        }

        // GET: Expense/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expense/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDExpense,ExpenseDate,ORNumber,Vendor,Particulars,Account,EncodedBy,ChargeToCodep,VATSales,VATAmount,VATExempt,Amount")] vrptExpens vrptExpens)
        {
            if (ModelState.IsValid)
            {
                db.vrptExpenses.Add(vrptExpens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrptExpens);
        }

        // GET: Expense/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrptExpens vrptExpens = db.vrptExpenses.Find(id);
            if (vrptExpens == null)
            {
                return HttpNotFound();
            }
            return View(vrptExpens);
        }

        // POST: Expense/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDExpense,ExpenseDate,ORNumber,Vendor,Particulars,Account,EncodedBy,ChargeToCodep,VATSales,VATAmount,VATExempt,Amount")] vrptExpens vrptExpens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vrptExpens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vrptExpens);
        }

        // GET: Expense/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrptExpens vrptExpens = db.vrptExpenses.Find(id);
            if (vrptExpens == null)
            {
                return HttpNotFound();
            }
            return View(vrptExpens);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vrptExpens vrptExpens = db.vrptExpenses.Find(id);
            db.vrptExpenses.Remove(vrptExpens);
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
