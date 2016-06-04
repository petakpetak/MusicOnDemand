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
    public class IzvodjacController : Controller
    {
        private MusicDB_Entities db = new MusicDB_Entities();

        // GET: /Izvodjac/
        public async Task<ActionResult> Index(string search = "")
        {
            if (search == "") {
                var izvođač = db.izvođač.Include(i => i.država);
                return View(await izvođač.ToListAsync());
          
            }
            var izvođačFilter = db.izvođač.Include(i => i.država).Where( k => k.nazivIzvođač.Trim().Contains(search.Trim()));
            return View(await izvođačFilter.ToListAsync());
        }

        // GET: /Izvodjac/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            izvođač izvođač = await db.izvođač.Include("album").FirstAsync(t => t.izvođačID == id);
            if (izvođač == null)
            {
                return HttpNotFound();
            }
            return View(izvođač);
        }

        // GET: /Izvodjac/Create
        public ActionResult Create()
        {
            ViewBag.državaID = new SelectList(db.država, "državaID", "nazivDržave");
            return View();
        }

        // POST: /Izvodjac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="izvođačID,nazivIzvođač,državaID")] izvođač izvođač)
        {
            if (ModelState.IsValid)
            {
                db.izvođač.Add(izvođač);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.državaID = new SelectList(db.država, "državaID", "nazivDržave", izvođač.državaID);
            return View(izvođač);
        }

        // GET: /Izvodjac/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            izvođač izvođač = await db.izvođač.FindAsync(id);
            if (izvođač == null)
            {
                return HttpNotFound();
            }
            ViewBag.državaID = new SelectList(db.država, "državaID", "nazivDržave", izvođač.državaID);
            return View(izvođač);
        }

        // POST: /Izvodjac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="izvođačID,nazivIzvođač,državaID")] izvođač izvođač)
        {
            if (ModelState.IsValid)
            {
                db.Entry(izvođač).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.državaID = new SelectList(db.država, "državaID", "nazivDržave", izvođač.državaID);
            return View(izvođač);
        }

        // GET: /Izvodjac/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            izvođač izvođač = await db.izvođač.FindAsync(id);
            if (izvođač == null)
            {
                return HttpNotFound();
            }
            return View(izvođač);
        }

        // POST: /Izvodjac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            izvođač izvođač = await db.izvođač.FindAsync(id);
            db.izvođač.Remove(izvođač);
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
