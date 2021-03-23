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
    public class InquiriesController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: Inquiries
        public ActionResult Index()
        {
            return View(db.tblInquiries.ToList());
        }

        // GET: Inquiries/Details/5
        public ActionResult Details(int? IDInquiry)
        {
            if (IDInquiry == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInquiry tblInquiry = db.tblInquiries.Find(IDInquiry);
            if (tblInquiry == null)
            {
                return HttpNotFound();
            }
            return View(tblInquiry);
        }

        // GET: Inquiries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inquiries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDInquiry,InquiryDate,Codep,ContactNo,Prospect,Details,FollowupOn,IDInquiryStatus")] tblInquiry tblInquiry)
        {
            if (ModelState.IsValid)
            {
                db.tblInquiries.Add(tblInquiry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblInquiry);
        }

        // GET: Inquiries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInquiry tblInquiry = db.tblInquiries.Find(id);
            if (tblInquiry == null)
            {
                return HttpNotFound();
            }
            return View(tblInquiry);
        }

        // POST: Inquiries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDInquiry,InquiryDate,Codep,ContactNo,Prospect,Details,FollowupOn,IDInquiryStatus")] tblInquiry tblInquiry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblInquiry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblInquiry);
        }

        // GET: Inquiries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInquiry tblInquiry = db.tblInquiries.Find(id);
            if (tblInquiry == null)
            {
                return HttpNotFound();
            }
            return View(tblInquiry);
        }

        // POST: Inquiries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblInquiry tblInquiry = db.tblInquiries.Find(id);
            db.tblInquiries.Remove(tblInquiry);
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
