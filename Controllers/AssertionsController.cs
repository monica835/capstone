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
    public class AssertionsController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: Assertions
        public ActionResult Index()
        {
            return View(db.tblAssertions.ToList());
        }

        // GET: Assertions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAssertion tblAssertion = db.tblAssertions.Find(id);
            if (tblAssertion == null)
            {
                return HttpNotFound();
            }
            return View(tblAssertion);
        }

        // GET: Assertions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assertions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAssertion,Description,IDAdmission,AssertionDate,IDAssertionCategory,Qty,Price,Markup,MarkupValue,SubTotal,Notes,IDChargeToCodep,PostedDate")] tblAssertion tblAssertion)
        {
            if (ModelState.IsValid)
            {
                db.tblAssertions.Add(tblAssertion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAssertion);
        }

        // GET: Assertions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAssertion tblAssertion = db.tblAssertions.Find(id);
            if (tblAssertion == null)
            {
                return HttpNotFound();
            }
            return View(tblAssertion);
        }

        // POST: Assertions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAssertion,Description,IDAdmission,AssertionDate,IDAssertionCategory,Qty,Price,Markup,MarkupValue,SubTotal,Notes,IDChargeToCodep,PostedDate")] tblAssertion tblAssertion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAssertion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAssertion);
        }

        // GET: Assertions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAssertion tblAssertion = db.tblAssertions.Find(id);
            if (tblAssertion == null)
            {
                return HttpNotFound();
            }
            return View(tblAssertion);
        }

        // POST: Assertions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAssertion tblAssertion = db.tblAssertions.Find(id);
            db.tblAssertions.Remove(tblAssertion);
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
