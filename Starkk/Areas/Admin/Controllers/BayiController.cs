using Starkk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Starkk.Areas.Admin.Controllers
{
    
    public class BayiController : AnaController
    {
        // GET: Admin/Bayi
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(DatabaseContext.Bayis.ToList());
        }

        // GET: Admin/Bayi/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bayi kargo = DatabaseContext.Bayis.Find(id);
            if (kargo == null)
            {
                return HttpNotFound();
            }
            return View(kargo);
        }

        // GET: Admin/Bayi/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Bayi/Create
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(Bayi model)
        {
           
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    DatabaseContext.Bayis.Add(model);
                     DatabaseContext.SaveChanges();
                    return RedirectToAction("Index","Home", new { area = "" });
                }
               
            
           
                return View(model);
            
        }

        // GET: Admin/Bayi/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bayi bayi = DatabaseContext.Bayis.Find(id);
            if (bayi == null)
            {
                return HttpNotFound();
            }
            return View(bayi);
        }

        // POST: Admin/Bayi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Edit(int id, Bayi model)
        {
            if (ModelState.IsValid)
            {
                DatabaseContext.Entry(model).State = EntityState.Modified;
                 DatabaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Admin/Bayi/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bayi kargo = DatabaseContext.Bayis.Find(id);
            if (kargo == null)
            {
                return HttpNotFound();
            }
            return View(kargo);
        }

        // POST: Admin/Bayi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       
        public ActionResult DeleteConfirmed(int id)
        {
            Bayi kargo = DatabaseContext.Bayis.Find(id);
            DatabaseContext.Bayis.Remove(kargo);
           DatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }





        //yeni olustur

        [Authorize(Roles = "Admin")]
        public ActionResult YeniOlustur()
        {
            return View();
        }

        // POST: Admin/Bayi/Create
        [HttpPost]
       
        public ActionResult YeniOlustur(Bayi model)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                DatabaseContext.Bayis.Add(model);
                DatabaseContext.SaveChanges();
                return RedirectToAction("Index");
            }



            return View(model);

        }
    }
}
