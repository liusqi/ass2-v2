﻿using System;
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
    public class FamilyViolenceFilesController : Controller
    {
        private LookupModel db = new LookupModel();

        // GET: FamilyViolenceFiles
        public ActionResult Index()
        {
            return View(db.FamilyViolenceFiles.ToList());
        }

        // GET: FamilyViolenceFiles/Details/5
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyViolenceFile familyViolenceFile = db.FamilyViolenceFiles.Find(id);
            if (familyViolenceFile == null)
            {
                return HttpNotFound();
            }
            return View(familyViolenceFile);
        }

        // GET: FamilyViolenceFiles/Create
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FamilyViolenceFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Create([Bind(Include = "id,value")] FamilyViolenceFile familyViolenceFile)
        {
            if (ModelState.IsValid)
            {
                db.FamilyViolenceFiles.Add(familyViolenceFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(familyViolenceFile);
        }

        // GET: FamilyViolenceFiles/Edit/5
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyViolenceFile familyViolenceFile = db.FamilyViolenceFiles.Find(id);
            if (familyViolenceFile == null)
            {
                return HttpNotFound();
            }
            return View(familyViolenceFile);
        }

        // POST: FamilyViolenceFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Edit([Bind(Include = "id,value")] FamilyViolenceFile familyViolenceFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familyViolenceFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(familyViolenceFile);
        }

        // GET: FamilyViolenceFiles/Delete/5
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyViolenceFile familyViolenceFile = db.FamilyViolenceFiles.Find(id);
            if (familyViolenceFile == null)
            {
                return HttpNotFound();
            }
            return View(familyViolenceFile);
        }

        // POST: FamilyViolenceFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Worker")]
        public ActionResult DeleteConfirmed(int id)
        {
            FamilyViolenceFile familyViolenceFile = db.FamilyViolenceFiles.Find(id);
            db.FamilyViolenceFiles.Remove(familyViolenceFile);
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
