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
    public class HakkimizdaController : AnaController
    {
        // GET: Admin/Hakkimizda
        public ActionResult Index()
        {
            return View(DatabaseContext.Hakkimizdas.ToList());
        }

        // GET: Admin/Hakkimizda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hakkimizda movie = DatabaseContext.Hakkimizdas.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Admin/Hakkimizda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hakkimizda/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Hakkimizda model)
        {
            try
            {
                DatabaseContext.Entry(model).State = EntityState.Added;
                DatabaseContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Hakkimizda/Edit/5
        public ActionResult Edit(int id=0)
        {
            Hakkimizda hak = DatabaseContext.Hakkimizdas.Find(id);
            if (hak==null)
            {
                return HttpNotFound();

            }
            return View(hak);
        }

        // POST: Admin/Hakkimizda/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Hakkimizda model)
        {
            try
            {

                // TODO: Add update logic here
                DatabaseContext.Entry(model).State = EntityState.Modified;
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

        // GET: Admin/Hakkimizda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hakkimizda hak = DatabaseContext.Hakkimizdas.Find(id);
            if (hak == null)
            {
                return HttpNotFound();
            }
            return View(hak);
            
        }

        // POST: Admin/Hakkimizda/Delete/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hakkimizda model)
        {
            try
            {
                // TODO: Add delete logic here

                Hakkimizda movie = DatabaseContext.Hakkimizdas.Find(id);
                if (movie == null)
                {
                    return HttpNotFound();
                }
                DatabaseContext.Hakkimizdas.Remove(movie);
                DatabaseContext.SaveChanges();
                return RedirectToAction("Index");

               
            }
            catch
            {
                return View();
            }
        }
    }
}
