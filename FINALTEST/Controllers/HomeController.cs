using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FINALTEST.Models;
using System.Globalization;

namespace FINALTEST.Controllers
{
    public class HomeController : Controller
    {
        private DisasterWarningContext db = new DisasterWarningContext();

        // GET: Home
        public ActionResult Index()
        {
            var query = from t in db.TobeSends
                        where (t.SendTime <= DateTime.Now && t.SendStatus == "To be Send")
                        select t;
            foreach (TobeSend x in query)
            {
                SentWarning y = new SentWarning
                {
                    MailSent = x.ContactDetail.UseMail,
                    SMSSent = x.ContactDetail.UseSMS,
                    SentTime = x.SendTime,
                    ContactDetail = x.ContactDetail,
                    Warning = x.Warning
                };
                db.SentWarnings.Add(y);
                x.SendStatus = "Has Been Sent";
            }
            db.SaveChanges();

            var tobeSends = db.TobeSends.Include(t => t.ContactDetail).Include(t => t.Warning);
            ViewBag.tobeSends = tobeSends;

            return View(tobeSends.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TobeSend tobeSend = db.TobeSends.Find(id);
            if (tobeSend == null)
            {
                return HttpNotFound();
            }
            return View(tobeSend);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.ContactDetailID = new SelectList(db.ContactDetails, "Id", "Name");
            ViewBag.WarningID = new SelectList(db.Warnings, "Id", "Title");

            var tobeSends = db.TobeSends.Include(t => t.ContactDetail).Include(t => t.Warning);
            ViewBag.tobeSends = tobeSends.ToList();

            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SendTime,SendStatus,ContactDetailID,WarningID")] TobeSend tobeSend, string SendDate, string SendTime, string TimeOption)
        {
            if (TimeOption == "set")
            {
                DateTime timeString = DateTime.Now;
                bool validated = true;
                try
                {
                    DateTime.ParseExact(SendDate.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString();
                }
                catch
                {
                    validated = false;
                    ViewBag.DateError = "Date is not valid!";
                }

                try
                {
                    DateTime.ParseExact(SendTime.Trim(), "HH:mm:ss", CultureInfo.InvariantCulture).ToString();
                }
                catch
                {
                    validated = false;
                    @ViewBag.TimeError = "Time is not valid!";
                }

                if(validated == true)
                {
                    timeString = DateTime.ParseExact(SendDate + " " + SendTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    if (timeString <= DateTime.Now)
                    {
                        validated = false;
                        @ViewBag.DateTimeError = "Inputed DateTime must be greater than current DateTime";
                    }
                }

                if (validated == true)
                {
                    tobeSend.SendTime = timeString;
                    tobeSend.SendStatus = "To be Send";

                    if (ModelState.IsValid)
                    {
                        foreach (ContactDetail item in db.ContactDetails.ToList())
                        {
                            tobeSend.ContactDetail = item;
                            db.TobeSends.Add(tobeSend);
                            db.SaveChanges();
                        }
                        return RedirectToAction("Index");
                    }
                }

                @ViewBag.DateValue = SendDate;
                @ViewBag.TimeValue = SendTime;

                ViewBag.ContactDetailID = new SelectList(db.ContactDetails, "Id", "Name", tobeSend.ContactDetailID);
                ViewBag.WarningID = new SelectList(db.Warnings, "Id", "Title", tobeSend.WarningID);

                var tobeSends = db.TobeSends.Include(t => t.ContactDetail).Include(t => t.Warning);
                ViewBag.tobeSends = tobeSends.ToList();

                return View(tobeSend);
            }

            tobeSend.SendTime = DateTime.Now;
            tobeSend.SendStatus = "To be Send";

            foreach (ContactDetail item in db.ContactDetails.ToList())
            {
                tobeSend.ContactDetail = item;
                db.TobeSends.Add(tobeSend);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TobeSend tobeSend = db.TobeSends.Find(id);
            if (tobeSend == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactDetailID = new SelectList(db.ContactDetails, "Id", "Name", tobeSend.ContactDetailID);
            ViewBag.WarningID = new SelectList(db.Warnings, "Id", "Title", tobeSend.WarningID);
            return View(tobeSend);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SendTime,SendStatus,ContactDetailID,WarningID")] TobeSend tobeSend)
        {
            if (ModelState.IsValid || tobeSend.SendTime <= DateTime.Now)
            {
                db.Entry(tobeSend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactDetailID = new SelectList(db.ContactDetails, "Id", "Name", tobeSend.ContactDetailID);
            ViewBag.WarningID = new SelectList(db.Warnings, "Id", "Title", tobeSend.WarningID);
            return View(tobeSend);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TobeSend tobeSend = db.TobeSends.Find(id);
            if (tobeSend == null)
            {
                return HttpNotFound();
            }
            return View(tobeSend);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TobeSend tobeSend = db.TobeSends.Find(id);
            db.TobeSends.Remove(tobeSend);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll(string id)
        {
            if (id == null || id == "")
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
            db.TobeSends.RemoveRange(db.TobeSends.ToList());
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
