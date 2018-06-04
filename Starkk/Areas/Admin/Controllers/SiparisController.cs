
using Starkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Starkk.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SiparisController : AnaController
    {

        // GET: Admin/Siparis
        public ActionResult Index()
        {
            var sipariss = DatabaseContext.Siparis.ToList();
            return View(sipariss.ToList());
        }

        public ActionResult Detay(int id)
        {
            var siparisDetay = DatabaseContext.SiparisKalems.Where(a => a.RefSiparisID == id).ToList();
            return View(siparisDetay);
        }


        //public JsonResult FaturaOlustur(int id)
        //{
        //    var siparis = DatabaseContext.Siparis.FirstOrDefault(s => s.Id == id);

        //    var jsonModel = new
        //    {
        //        isim=siparis.Ad,
        //        soyisim=siparis.Soyad,
        //        Adres=siparis.Adres,
        //        Telefon=siparis.Telefon,
        //        Tc=siparis.TcKimlikNo,
        //        SiparisNo=siparis.Id,
        //        OdemeTarihi=siparis.Tarih,
        //        UyeId=siparis.RefAspNetUserID,
        //        SiparisKalem = from o in siparis.SiparisKalems
        //                select new
        //                {
        //                    Id = o.Id,
        //                    Adet =o.Adet,
        //                    UrunAdi=o.Urunler.UrunAdi,
        //                    UrunId=o.RefUrunID,
        //                    Fiyati=o.Urunler.Fiyat,
        //                    toplam=o.ToplamTutar
                            

        //                }



        //    };
        //    return Json(jsonModel, JsonRequestBehavior.AllowGet);

        //}

        public ActionResult FaturaOlustur(int id)
        {
           
            return View(DatabaseContext.Siparis.Find(id));
        }

    }
}