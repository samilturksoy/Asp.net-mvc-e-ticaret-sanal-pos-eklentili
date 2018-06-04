using PagedList;
using Starkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Starkk.Controllers
{
    public class UrunlerController : AnaController
    {
        // GET: Urunler
        public ActionResult Index(int sayfa=1)
        {
            ViewBag.Resimler = DatabaseContext.ResimUruns.ToList();
            return View(DatabaseContext.Urunlers.OrderBy(x => x.UrunAdi).ToPagedList(sayfa, 6));
        }



        public ActionResult UrunDetay(int? id)
        {
            ViewBag.Resimler = DatabaseContext.ResimUruns.Where(p => p.RefUrunId == id).ToList();
            return View(DatabaseContext.Urunlers.Find(id));
        }
    }
}