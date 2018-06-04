using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Starkk.Models;

namespace Starkk.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class KargoController : Controller
    {
        private StarkmssEntities db = new StarkmssEntities();

        // GET: Admin/Kargo
        public async Task<ActionResult> Index()
        {
            return View(await db.Kargoes.ToListAsync());
        }

        // GET: Admin/Kargo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kargo kargo = await db.Kargoes.FindAsync(id);
            if (kargo == null)
            {
                return HttpNotFound();
            }
            return View(kargo);
        }

        // GET: Admin/Kargo/Create
       
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Kargo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Create([Bind(Include = "Id,KargoAdi")] Kargo kargo)
        {
            if (ModelState.IsValid)
            {
                db.Kargoes.Add(kargo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(kargo);
        }

        // GET: Admin/Kargo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kargo kargo = await db.Kargoes.FindAsync(id);
            if (kargo == null)
            {
                return HttpNotFound();
            }
            return View(kargo);
        }

        // POST: Admin/Kargo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,KargoAdi")] Kargo kargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kargo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(kargo);
        }

        // GET: Admin/Kargo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kargo kargo = await db.Kargoes.FindAsync(id);
            if (kargo == null)
            {
                return HttpNotFound();
            }
            return View(kargo);
        }

        // POST: Admin/Kargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kargo kargo = await db.Kargoes.FindAsync(id);
            db.Kargoes.Remove(kargo);
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
