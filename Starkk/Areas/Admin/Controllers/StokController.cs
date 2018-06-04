using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Starkk.Models;

namespace Starkk.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StokController : Controller
    {
        private StarkmssEntities db = new StarkmssEntities();

        // GET: Admin/Stok
        public ActionResult Index()
        {
            //total para
            ViewBag.Total = db.Stoks.Sum(m => m.Fiyatı * m.Adet).ToString();
            return View(db.Stoks.ToList());
        }

        // GET: Admin/Stok/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stoks.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            //total para
            ViewBag.Total = db.Stoks.Sum(m => m.Fiyatı * m.Adet).ToString();
            return View(stok);
        }

        // GET: Admin/Stok/Create
        public ActionResult Create()
        {
            //total para
            ViewBag.Total = db.Stoks.Sum(m => m.Fiyatı * m.Adet).ToString();
            return View();
        }

        // POST: Admin/Stok/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Stok stok)
        {
            if (ModelState.IsValid)
            {
                db.Stoks.Add(stok);
                db.SaveChanges();
                //total para
                ViewBag.Total = db.Stoks.Sum(m => m.Fiyatı * m.Adet).ToString();
                return RedirectToAction("Index");
            }
            //total para
            ViewBag.Total = db.Stoks.Sum(m => m.Fiyatı * m.Adet).ToString();
            return View(stok);
        }

        // GET: Admin/Stok/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stoks.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            //total para
            ViewBag.Total = db.Stoks.Sum(m => m.Fiyatı * m.Adet).ToString();
            return View(stok);
        }

        // POST: Admin/Stok/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Stok stok)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stok).State = EntityState.Modified;
                db.SaveChanges();
                //total para
                ViewBag.Total = db.Stoks.Sum(m => m.Fiyatı * m.Adet).ToString();
                return RedirectToAction("Index");
            }
            //total para
            ViewBag.Total = db.Stoks.Sum(m => m.Fiyatı * m.Adet).ToString();
            return View(stok);
        }

        // GET: Admin/Stok/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stoks.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            //total para
            ViewBag.Total = db.Stoks.Sum(m => m.Fiyatı * m.Adet).ToString();
            return View(stok);
        }

        // POST: Admin/Stok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stok stok = db.Stoks.Find(id);
            db.Stoks.Remove(stok);
            db.SaveChanges();
            //total para
            ViewBag.Total = db.Stoks.Sum(m => m.Fiyatı * m.Adet).ToString();
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
