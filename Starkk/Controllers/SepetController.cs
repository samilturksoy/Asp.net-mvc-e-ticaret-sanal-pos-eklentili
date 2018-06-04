using Microsoft.AspNet.Identity;
using Starkk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Starkk.Controllers
{
    [Authorize]
    public class SepetController : AnaController
    {
        // GET: Sepet
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var sepets = DatabaseContext.Sepets.Where(a => a.RefAspNetUserID == userId).Include(s => s.Urunler);
            return View(sepets.ToList());
        }


        public ActionResult SepeteEkle(int id,int? adet)
        {
            string userId = User.Identity.GetUserId();

            Sepet sepettekiUrun = DatabaseContext.Sepets.FirstOrDefault(a => a.RefUrunId == id && a.RefAspNetUserID == userId);
            Urunler urun = DatabaseContext.Urunlers.Find(id);
            if (sepettekiUrun==null)
            {
                Sepet yeniUrun = new Sepet()
                {
                    RefAspNetUserID = userId,
                    RefUrunId = id,
                    Adet = adet ?? 1,
                    ToplamTutar = (adet ?? 1) * urun.Fiyat
                };
                DatabaseContext.Sepets.Add(yeniUrun);

            }
            else
            {
                sepettekiUrun.Adet = sepettekiUrun.Adet + (adet ?? 1);
                sepettekiUrun.ToplamTutar = sepettekiUrun.Adet * urun.Fiyat;
            }
            DatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }




        public ActionResult SepetGuncelle(int? adet,int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepet sepet = DatabaseContext.Sepets.Find(id);
            if (sepet==null)
            {
                return HttpNotFound();
            }
            Urunler urun = DatabaseContext.Urunlers.Find(sepet.RefUrunId);
            sepet.Adet = adet ?? 1;
            sepet.ToplamTutar = sepet.Adet * urun.Fiyat;
            DatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Sil(int id)
        {
            Sepet sepet = DatabaseContext.Sepets.Find(id);
            DatabaseContext.Sepets.Remove(sepet);
            DatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}