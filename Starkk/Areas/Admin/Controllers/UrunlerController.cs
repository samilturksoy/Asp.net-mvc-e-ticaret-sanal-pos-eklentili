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
using System.Web.Helpers;
using System.Data.Entity.Validation;

namespace Starkk.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UrunlerController : Controller
    {
        private StarkmssEntities db = new StarkmssEntities();

        // GET: Admin/Urunler
        public async Task<ActionResult> Index()
        {
            try
            {
                var urunlers = db.Urunlers.Include(u => u.Kategori);
                
                return View(await urunlers.ToListAsync());
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

        // GET: Admin/Urunler/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = await db.Urunlers.FindAsync(id);
            ViewBag.Resimler = db.ResimUruns.Where(p => p.RefUrunId == id).ToList();
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // GET: Admin/Urunler/Create
        public ActionResult Create()
        {
            ViewBag.RefKategoriId = new SelectList(db.Kategoris, "Id", "KategoriAdi");
            return View();
        }

        // POST: Admin/Urunler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create([Bind(Include = "Id,RefKategoriId,UrunAdi,UrunAciklamasi,Fiyat")] Urunler urunler,ResimUrun resim)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Urunlers.Add(urunler);
                    await db.SaveChangesAsync();

                    if (resim.ResimFile != null)
                    {
                        foreach (var item in resim.ResimFile)
                        {
                            resim.Resim = new WebImage(item.InputStream).Resize(801, 801, preserveAspectRatio: false).Crop(1, 1).GetBytes("jpeg");
                            resim.RefUrunId = urunler.Id;

                            db.ResimUruns.Add(resim);
                            await db.SaveChangesAsync();

                        }
                        

                        
                    }



                    return RedirectToAction("Index");
                }

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
            

            ViewBag.RefKategoriId = new SelectList(db.Kategoris, "Id", "KategoriAdi", urunler.RefKategoriId);
            return View(urunler);
        }

        // GET: Admin/Urunler/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = await db.Urunlers.FindAsync(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            ViewBag.RefKategoriId = new SelectList(db.Kategoris, "Id", "KategoriAdi", urunler.RefKategoriId);
            ViewBag.Resimler = db.ResimUruns.Where(p => p.RefUrunId == id).ToList();
            return View(urunler);
        }

        // POST: Admin/Urunler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RefKategoriId,UrunAdi,UrunAciklamasi,Fiyat")] Urunler urunler, ResimUrun resim)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(urunler).State = EntityState.Modified;
                    await db.SaveChangesAsync();


                    try
                    {
                        if (resim.ResimFile != null)
                        {
                            foreach (var item in resim.ResimFile)
                            {
                                resim.Resim = new WebImage(item.InputStream).Resize(801, 801, preserveAspectRatio: false).Crop(1, 1).GetBytes("jpeg");
                                resim.RefUrunId = urunler.Id;

                                db.ResimUruns.Add(resim);
                                await db.SaveChangesAsync();

                            }


                        }
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("Index");
                    }
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
            ViewBag.RefKategoriId = new SelectList(db.Kategoris, "Id", "KategoriAdi", urunler.RefKategoriId);
            
            return View(urunler);
        }

        // GET: Admin/Urunler/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = await db.Urunlers.FindAsync(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // POST: Admin/Urunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Urunler urunler = await db.Urunlers.FindAsync(id);

            db.ResimUruns.RemoveRange(urunler.ResimUruns);
            
            db.Urunlers.Remove(urunler);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Deleteimg(int id)
        {
            ResimUrun resim = await db.ResimUruns.FindAsync(id);
            db.ResimUruns.Remove(resim);
            await db.SaveChangesAsync();
            ViewBag.Resimler = db.ResimUruns.Where(p => p.RefUrunId == p.Urunler.Id).ToList();
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
