using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FINALTEST.Models;

namespace FINALTEST.Controllers
{
    public class SentWarningsController : Controller
    {
        private DisasterWarningContext db = new DisasterWarningContext();

        // GET: SentWarnings
        public ActionResult Index()
        {
            var sentWarnings = db.SentWarnings.Include(s => s.ContactDetail).Include(s => s.Warning);
            return View(sentWarnings.ToList());
        }

        // GET: SentWarnings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SentWarning sentWarning = db.SentWarnings.Find(id);
            if (sentWarning == null)
            {
                return HttpNotFound();
            }
            return View(sentWarning);
        }

        // GET: SentWarnings/Create
        public ActionResult Create()
        {
            ViewBag.ContactDetailID = new SelectList(db.ContactDetails, "Id", "Name");
            ViewBag.WarningID = new SelectList(db.Warnings, "Id", "Title");
            return View();
        }

        // POST: SentWarnings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MailSent,SMSSent,SentTime,ContactDetailID,WarningID")] SentWarning sentWarning)
        {
            if (ModelState.IsValid)
            {
                db.SentWarnings.Add(sentWarning);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactDetailID = new SelectList(db.ContactDetails, "Id", "Name", sentWarning.ContactDetailID);
            ViewBag.WarningID = new SelectList(db.Warnings, "Id", "Title", sentWarning.WarningID);
            return View(sentWarning);
        }

        // GET: SentWarnings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SentWarning sentWarning = db.SentWarnings.Find(id);
            if (sentWarning == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactDetailID = new SelectList(db.ContactDetails, "Id", "Name", sentWarning.ContactDetailID);
            ViewBag.WarningID = new SelectList(db.Warnings, "Id", "Title", sentWarning.WarningID);
            return View(sentWarning);
        }

        // POST: SentWarnings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MailSent,SMSSent,SentTime,ContactDetailID,WarningID")] SentWarning sentWarning)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sentWarning).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactDetailID = new SelectList(db.ContactDetails, "Id", "Name", sentWarning.ContactDetailID);
            ViewBag.WarningID = new SelectList(db.Warnings, "Id", "Title", sentWarning.WarningID);
            return View(sentWarning);
        }

        // GET: SentWarnings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SentWarning sentWarning = db.SentWarnings.Find(id);
            if (sentWarning == null)
            {
                return HttpNotFound();
            }
            return View(sentWarning);
        }

        // POST: SentWarnings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SentWarning sentWarning = db.SentWarnings.Find(id);
            db.SentWarnings.Remove(sentWarning);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: SentWarnings/Delete/5
        public ActionResult DeleteAll(string id)
        {
            if (id == null || id =="")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }

        // POST: SentWarnings/Delete/5
        [HttpPost, ActionName("DeleteAll")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAllConfirmed(string id)
        {
            db.SentWarnings.RemoveRange(db.SentWarnings.ToList());
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
