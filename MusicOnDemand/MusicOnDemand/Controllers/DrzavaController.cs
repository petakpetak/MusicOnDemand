using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicOnDemand.Models;

namespace MusicOnDemand.Controllers
{
    public class DrzavaController : Controller
    {
        private MusicDB_Entities db = new MusicDB_Entities();

        // GET: /Drzava/
        public async Task<ActionResult> Index()
        {
            return View(await db.država.ToListAsync());
        }

        // GET: /Drzava/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            država država = await db.država.FindAsync(id);
            if (država == null)
            {
                return HttpNotFound();
            }
            return View(država);
        }

        // GET: /Drzava/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Drzava/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="državaID,nazivDržave")] država država)
        {
            if (ModelState.IsValid)
            {
                db.država.Add(država);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(država);
        }

        // GET: /Drzava/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            država država = await db.država.FindAsync(id);
            if (država == null)
            {
                return HttpNotFound();
            }
            return View(država);
        }

        // POST: /Drzava/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="državaID,nazivDržave")] država država)
        {
            if (ModelState.IsValid)
            {
                db.Entry(država).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(država);
        }

        // GET: /Drzava/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            država država = await db.država.FindAsync(id);
            if (država == null)
            {
                return HttpNotFound();
            }
            return View(država);
        }

        // POST: /Drzava/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            država država = await db.država.FindAsync(id);
            db.država.Remove(država);
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
