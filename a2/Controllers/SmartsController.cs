using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            return View(await db.Smarts.ToListAsync());
        }

        // GET: Smarts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smart smart = await db.Smarts.FindAsync(id);
            if (smart == null)
            {
                return HttpNotFound();
            }
            return View(smart);
        }

        // GET: Smarts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Smarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,AccompanimentMinutes,NumberTransportsProvided,ReferredToNursePractitioner")] Smart smart)
        {
            if (ModelState.IsValid)
            {
                db.Smarts.Add(smart);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(smart);
        }

        // GET: Smarts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smart smart = await db.Smarts.FindAsync(id);
            if (smart == null)
            {
                return HttpNotFound();
            }
            return View(smart);
        }

        // POST: Smarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,AccompanimentMinutes,NumberTransportsProvided,ReferredToNursePractitioner")] Smart smart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smart).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(smart);
        }

        // GET: Smarts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smart smart = await db.Smarts.FindAsync(id);
            if (smart == null)
            {
                return HttpNotFound();
            }
            return View(smart);
        }

        // POST: Smarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Smart smart = await db.Smarts.FindAsync(id);
            db.Smarts.Remove(smart);
            await db.SaveChangesAsync();
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
