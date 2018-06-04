using Starkk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Starkk.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IletisimController : AnaController
    {
        // GET: Admin/Iletisim
        public ActionResult Index()
        {
            return View(DatabaseContext.Iletisims.ToList());
        }

        // GET: Admin/Iletisim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iletisim movie = DatabaseContext.Iletisims.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Admin/Iletisim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Iletisim/Create
        [HttpPost]
        public ActionResult Create(Iletisim model)
        {
            try
            {
                
                DatabaseContext.Entry(model).State = EntityState.Added;
                DatabaseContext.SaveChanges();
                // TODO: Add insert logic here

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

        // GET: Admin/Iletisim/Edit/5
        public ActionResult Edit(int id=0)
        {
            Iletisim hak = DatabaseContext.Iletisims.Find(id);
            if (hak == null)
            {
                return HttpNotFound();

            }
            return View(hak);
        }

        // POST: Admin/Iletisim/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Iletisim model)
        {
            try
            {

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

        // GET: Admin/Iletisim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iletisim hak = DatabaseContext.Iletisims.Find(id);
            if (hak == null)
            {
                return HttpNotFound();
            }
            return View(hak);
        }

        // POST: Admin/Iletisim/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Iletisim model)
        {
            try
            {
                // TODO: Add delete logic here

                Iletisim movie = DatabaseContext.Iletisims.Find(id);
                if (movie == null)
                {
                    return HttpNotFound();
                }
                DatabaseContext.Iletisims.Remove(movie);
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
    }
}
