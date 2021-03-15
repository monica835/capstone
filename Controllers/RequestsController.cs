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
    public class RequestsController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: Requests
        public ActionResult Index()
        {
            return View(db.tblRequests.ToList());
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRequest tblRequest = db.tblRequests.Find(id);
            if (tblRequest == null)
            {
                return HttpNotFound();
            }
            return View(tblRequest);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRequest,DateRequest,DateNeeded,RequestedBy,Request,Budget,ApprovedBy,IDRequestStatus,ApproverNotes,DateApproved,RequestorEmail,DateAcc,RequestorNotes")] tblRequest tblRequest)
        {
            if (ModelState.IsValid)
            {
                db.tblRequests.Add(tblRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblRequest);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRequest tblRequest = db.tblRequests.Find(id);
            if (tblRequest == null)
            {
                return HttpNotFound();
            }
            return View(tblRequest);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRequest,DateRequest,DateNeeded,RequestedBy,Request,Budget,ApprovedBy,IDRequestStatus,ApproverNotes,DateApproved,RequestorEmail,DateAcc,RequestorNotes")] tblRequest tblRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblRequest);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRequest tblRequest = db.tblRequests.Find(id);
            if (tblRequest == null)
            {
                return HttpNotFound();
            }
            return View(tblRequest);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRequest tblRequest = db.tblRequests.Find(id);
            db.tblRequests.Remove(tblRequest);
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
