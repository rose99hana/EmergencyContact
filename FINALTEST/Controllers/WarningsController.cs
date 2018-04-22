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
    public class WarningsController : Controller
    {
        private DisasterWarningContext db = new DisasterWarningContext();

        // GET: Warnings
        public ActionResult Index()
        {
            return View(db.Warnings.ToList());
        }

        // GET: Warnings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warning warning = db.Warnings.Find(id);
            if (warning == null)
            {
                return HttpNotFound();
            }
            return View(warning);
        }

        // GET: Warnings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warnings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Detail")] Warning warning)
        {
            if (ModelState.IsValid)
            {
                db.Warnings.Add(warning);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warning);
        }

        // GET: Warnings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warning warning = db.Warnings.Find(id);
            if (warning == null)
            {
                return HttpNotFound();
            }
            return View(warning);
        }

        // POST: Warnings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Detail")] Warning warning)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warning).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warning);
        }

        // GET: Warnings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warning warning = db.Warnings.Find(id);
            if (warning == null)
            {
                return HttpNotFound();
            }
            return View(warning);
        }

        // POST: Warnings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Warning warning = db.Warnings.Find(id);
            db.Warnings.Remove(warning);
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
