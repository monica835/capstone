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
    public class vrptAssertionSummariesController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: vrptAssertionSummaries
        public ActionResult Index()
        {
            return View(db.vrptAssertionSummaries.ToList());
        }

        // GET: vrptAssertionSummaries/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrptAssertionSummary vrptAssertionSummary = db.vrptAssertionSummaries.Find(id);
            if (vrptAssertionSummary == null)
            {
                return HttpNotFound();
            }
            return View(vrptAssertionSummary);
        }

        // GET: vrptAssertionSummaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vrptAssertionSummaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Resident,AssertionDate,PostedDate,Description,Category,Qty,Price,Cost,Markup,MarkupValue,Margin,SubTotal")] vrptAssertionSummary vrptAssertionSummary)
        {
            if (ModelState.IsValid)
            {
                db.vrptAssertionSummaries.Add(vrptAssertionSummary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrptAssertionSummary);
        }

        // GET: vrptAssertionSummaries/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrptAssertionSummary vrptAssertionSummary = db.vrptAssertionSummaries.Find(id);
            if (vrptAssertionSummary == null)
            {
                return HttpNotFound();
            }
            return View(vrptAssertionSummary);
        }

        // POST: vrptAssertionSummaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Resident,AssertionDate,PostedDate,Description,Category,Qty,Price,Cost,Markup,MarkupValue,Margin,SubTotal")] vrptAssertionSummary vrptAssertionSummary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vrptAssertionSummary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vrptAssertionSummary);
        }

        // GET: vrptAssertionSummaries/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrptAssertionSummary vrptAssertionSummary = db.vrptAssertionSummaries.Find(id);
            if (vrptAssertionSummary == null)
            {
                return HttpNotFound();
            }
            return View(vrptAssertionSummary);
        }

        // POST: vrptAssertionSummaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            vrptAssertionSummary vrptAssertionSummary = db.vrptAssertionSummaries.Find(id);
            db.vrptAssertionSummaries.Remove(vrptAssertionSummary);
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
