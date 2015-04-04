using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using a2.Models;

namespace a2.Controllers
{
    public class SmartsController : Controller
    {
        private LookupModel db = new LookupModel();

        // GET: Smarts
        public ActionResult Index()
        {
            return View(db.Smarts.ToList());
        }

        // GET: Smarts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smart smart = db.Smarts.Find(id);
            if (smart == null)
            {
                return HttpNotFound();
            }
            return View(smart);
        }

        [Authorize(Roles = "Administrator, Worker")]
        // GET: Smarts/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Clients, "id", "Surname");
            return View();
        }

        // POST: Smarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Create([Bind(Include = "id,AccompanimentMinutes,NumberTransportsProvided,ReferredToNursePractitioner")] Smart smart)
        {
            if (ModelState.IsValid)
            {
                db.Smarts.Add(smart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Clients, "id", "Surname", smart.id);
            return View(smart);
        }

        // GET: Smarts/Edit/5
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smart smart = db.Smarts.Find(id);
            if (smart == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Clients, "id", "Surname", smart.id);
            return View(smart);
        }

        // POST: Smarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Edit([Bind(Include = "id,AccompanimentMinutes,NumberTransportsProvided,ReferredToNursePractitioner")] Smart smart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Clients, "id", "Surname", smart.id);
            return View(smart);
        }

        // GET: Smarts/Delete/5
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smart smart = db.Smarts.Find(id);
            if (smart == null)
            {
                return HttpNotFound();
            }
            return View(smart);
        }

        // POST: Smarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult DeleteConfirmed(int id)
        {
            Smart smart = db.Smarts.Find(id);
            db.Smarts.Remove(smart);
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
