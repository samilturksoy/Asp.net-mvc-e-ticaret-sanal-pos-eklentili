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
using System.Data.Entity.Validation;

namespace Starkk.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BlogYaziController : Controller
    {
        private StarkmssEntities db = new StarkmssEntities();

        // GET: Admin/BlogYazi
        public async Task<ActionResult> Index()
        {
            var blogYazis = db.BlogYazis.Include(b => b.BlogKategori);
            return View(await blogYazis.ToListAsync());
        }

        // GET: Admin/BlogYazi/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogYazi blogYazi = await db.BlogYazis.FindAsync(id);
            if (blogYazi == null)
            {
                return HttpNotFound();
            }
            return View(blogYazi);
        }

        // GET: Admin/BlogYazi/Create
        public ActionResult Create()
        {
            ViewBag.RefBlogKategoriId = new SelectList(db.BlogKategoris, "Id", "BlogKategoriAdi");
            return View();
        }

        // POST: Admin/BlogYazi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create([Bind(Include = "Id,RefBlogKategoriId,Baslik,Yazi,Tarih,Yazar,Seo")] BlogYazi blogYazi)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.BlogYazis.Add(blogYazi);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Response.Write(string.Format("Entity türü \"{0}\" şu hatalara sahip \"{1}\" Geçerlilik hataları:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Response.Write(string.Format("- Özellik: \"{0}\", Hata: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                        }
                        Response.End();
                    }
                    return View();
                }
               
            }

            ViewBag.RefBlogKategoriId = new SelectList(db.BlogKategoris, "Id", "BlogKategoriAdi", blogYazi.RefBlogKategoriId);
            return View(blogYazi);
        }

        // GET: Admin/BlogYazi/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogYazi blogYazi = await db.BlogYazis.FindAsync(id);
            if (blogYazi == null)
            {
                return HttpNotFound();
            }
            ViewBag.RefBlogKategoriId = new SelectList(db.BlogKategoris, "Id", "BlogKategoriAdi", blogYazi.RefBlogKategoriId);
            return View(blogYazi);
        }

        // POST: Admin/BlogYazi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RefBlogKategoriId,Baslik,Yazi,Tarih,Yazar,Seo")] BlogYazi blogYazi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogYazi).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RefBlogKategoriId = new SelectList(db.BlogKategoris, "Id", "BlogKategoriAdi", blogYazi.RefBlogKategoriId);
            return View(blogYazi);
        }

        // GET: Admin/BlogYazi/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogYazi blogYazi = await db.BlogYazis.FindAsync(id);
            if (blogYazi == null)
            {
                return HttpNotFound();
            }
            return View(blogYazi);
        }

        // POST: Admin/BlogYazi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BlogYazi blogYazi = await db.BlogYazis.FindAsync(id);
            db.BlogYazis.Remove(blogYazi);
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
