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
    public class AlbumController : Controller
    {
        private MusicDB_Entities db = new MusicDB_Entities();

        // GET: /Album/
        public async Task<ActionResult> Index()
        {
            var album = db.album.Include(a => a.izvođač).Include(a => a.žanr);
            return View(await album.ToListAsync());
        }

        // GET: /Album/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            album album = await db.album.FindAsync(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: /Album/Create
        public ActionResult Create()
        {
            ViewBag.izvođačID = new SelectList(db.izvođač, "izvođačID", "nazivIzvođač");
            ViewBag.žanrID = new SelectList(db.žanr, "žanrID", "nazivŽanra");
            return View();
        }

        // POST: /Album/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="albumID,izvođačID,žanrID,nazivAlbuma,godIzdanja")] album album)
        {
            if (ModelState.IsValid)
            {
                db.album.Add(album);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.izvođačID = new SelectList(db.izvođač, "izvođačID", "nazivIzvođač", album.izvođačID);
            ViewBag.žanrID = new SelectList(db.žanr, "žanrID", "nazivŽanra", album.žanrID);
            return View(album);
        }

        // GET: /Album/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            album album = await db.album.FindAsync(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.izvođačID = new SelectList(db.izvođač, "izvođačID", "nazivIzvođač", album.izvođačID);
            ViewBag.žanrID = new SelectList(db.žanr, "žanrID", "nazivŽanra", album.žanrID);
            return View(album);
        }

        // POST: /Album/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="albumID,izvođačID,žanrID,nazivAlbuma,godIzdanja")] album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.izvođačID = new SelectList(db.izvođač, "izvođačID", "nazivIzvođač", album.izvođačID);
            ViewBag.žanrID = new SelectList(db.žanr, "žanrID", "nazivŽanra", album.žanrID);
            return View(album);
        }

        // GET: /Album/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            album album = await db.album.FindAsync(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: /Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            album album = await db.album.FindAsync(id);
            db.album.Remove(album);
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
