using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using a2.Models;

namespace a2.Controllers.LookupControllers
{
    public class AbuserRelationshipsController : Controller
    {
        private LookupModel db = new LookupModel();

        // GET: AbuserRelationships
        public ActionResult Index()
        {
            return View(db.AbuserRelationships.ToList());
        }

        // GET: AbuserRelationships/Details/5
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbuserRelationship abuserRelationship = db.AbuserRelationships.Find(id);
            if (abuserRelationship == null)
            {
                return HttpNotFound();
            }
            return View(abuserRelationship);
        }

        // GET: AbuserRelationships/Create
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbuserRelationships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Create([Bind(Include = "id,value")] AbuserRelationship abuserRelationship)
        {
            if (ModelState.IsValid)
            {
                db.AbuserRelationships.Add(abuserRelationship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abuserRelationship);
        }

        // GET: AbuserRelationships/Edit/5
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbuserRelationship abuserRelationship = db.AbuserRelationships.Find(id);
            if (abuserRelationship == null)
            {
                return HttpNotFound();
            }
            return View(abuserRelationship);
        }

        // POST: AbuserRelationships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Edit([Bind(Include = "id,value")] AbuserRelationship abuserRelationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abuserRelationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abuserRelationship);
        }

        // GET: AbuserRelationships/Delete/5
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbuserRelationship abuserRelationship = db.AbuserRelationships.Find(id);
            if (abuserRelationship == null)
            {
                return HttpNotFound();
            }
            return View(abuserRelationship);
        }

        // POST: AbuserRelationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult DeleteConfirmed(int id)
        {
            AbuserRelationship abuserRelationship = db.AbuserRelationships.Find(id);
            db.AbuserRelationships.Remove(abuserRelationship);
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
