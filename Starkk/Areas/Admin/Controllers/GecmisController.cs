using Starkk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Starkk.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GecmisController : AnaController
    {
        // GET: Admin/Gecmis
        public ActionResult Index()
        {
            return View(DatabaseContext.Histories.ToList());
        }

        // GET: Admin/Gecmis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History movie = DatabaseContext.Histories.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Admin/Gecmis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Gecmis/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(History model)
        {

            try
            {
                if (model.ResimFile != null)
                {
                    model.Resim = new WebImage(model.ResimFile.InputStream).Resize(301, 201, preserveAspectRatio: false).Crop(1, 1).GetBytes("jpeg");
                }
                DatabaseContext.Entry(model).State = EntityState.Added;
                DatabaseContext.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch(DbEntityValidationException e)
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

        // GET: Admin/Gecmis/Edit/5
        public ActionResult Edit(int id=0)
        {
            History hak = DatabaseContext.Histories.Find(id);
            if (hak == null)
            {
                return HttpNotFound();

            }
            return View(hak);
        }

        // POST: Admin/Gecmis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, History model)
        {
            try
            {
                if (model.ResimFile != null)
                {
                    model.Resim = new WebImage(model.ResimFile.InputStream).Resize(301, 201, preserveAspectRatio: false).Crop(1, 1).GetBytes("jpeg");
                }

                // TODO: Add update logic here
                DatabaseContext.Entry(model).State = EntityState.Modified;
                DatabaseContext.SaveChanges();

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

        // GET: Admin/Gecmis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History hak = DatabaseContext.Histories.Find(id);
            if (hak == null)
            {
                return HttpNotFound();
            }
            return View(hak);
        }

        // POST: Admin/Gecmis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, History model)
        {
            try
            {
                // TODO: Add delete logic here

                History movie = DatabaseContext.Histories.Find(id);
                if (movie == null)
                {
                    return HttpNotFound();
                }
                DatabaseContext.Histories.Remove(movie);
                DatabaseContext.SaveChanges();
                return RedirectToAction("Index");


            }
            catch(DbEntityValidationException e)
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
    }
}
