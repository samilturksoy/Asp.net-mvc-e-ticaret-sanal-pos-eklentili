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
    public class BlogController : Controller
    {
        private StarkmssEntities db = new StarkmssEntities();

        // GET: Admin/Blog
        public async Task<ActionResult> Index()
        {
            return View(await db.BlogKategoris.ToListAsync());
        }

        // GET: Admin/Blog/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogKategori blogKategori = await db.BlogKategoris.FindAsync(id);
            if (blogKategori == null)
            {
                return HttpNotFound();
            }
            return View(blogKategori);
        }

        // GET: Admin/Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,BlogKategoriAdi")] BlogKategori blogKategori)
        {
            if (ModelState.IsValid)
            {
                db.BlogKategoris.Add(blogKategori);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(blogKategori);
        }

        // GET: Admin/Blog/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogKategori blogKategori = await db.BlogKategoris.FindAsync(id);
            if (blogKategori == null)
            {
                return HttpNotFound();
            }
            return View(blogKategori);
        }

        // POST: Admin/Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,BlogKategoriAdi")] BlogKategori blogKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogKategori).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(blogKategori);
        }

        // GET: Admin/Blog/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogKategori blogKategori = await db.BlogKategoris.FindAsync(id);
            if (blogKategori == null)
            {
                return HttpNotFound();
            }
            return View(blogKategori);
        }

        // POST: Admin/Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BlogKategori blogKategori = await db.BlogKategoris.FindAsync(id);
            db.BlogKategoris.Remove(blogKategori);
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
