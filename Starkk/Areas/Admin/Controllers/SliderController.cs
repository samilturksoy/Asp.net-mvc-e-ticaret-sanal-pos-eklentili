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
    public class SliderController : Controller
    {
        private StarkmssEntities db = new StarkmssEntities();

        // GET: Admin/Slider
        public async Task<ActionResult> Index()
        {
            return View(await db.Sliders.ToListAsync());
        }

        // GET: Admin/Slider/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = await db.Sliders.FindAsync(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Admin/Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Slider model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (model.ResimFile != null)
                    {
                        model.Resim = new WebImage(model.ResimFile.InputStream).Resize(1349, 501, preserveAspectRatio: false).Crop(1, 1).GetBytes("jpeg");
                    }

                    db.Sliders.Add(model);
                    await db.SaveChangesAsync();
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
           

            return View(model);
        }

        // GET: Admin/Slider/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = await db.Sliders.FindAsync(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Slider slider)
        {
            if (ModelState.IsValid)
            {
                if (slider.ResimFile != null)
                {
                    slider.Resim = new WebImage(slider.ResimFile.InputStream).Resize(1349, 501, preserveAspectRatio: false).Crop(1, 1).GetBytes("jpeg");
                }

                db.Entry(slider).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Admin/Slider/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = await db.Sliders.FindAsync(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Slider slider = await db.Sliders.FindAsync(id);
            db.Sliders.Remove(slider);
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
