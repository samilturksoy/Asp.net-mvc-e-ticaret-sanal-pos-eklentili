using Microsoft.AspNet.Identity;
using Starkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Starkk.Controllers
{
    [Authorize]
    public class SiparisController : AnaController
    {
        // GET: Siparis
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SiparisTamamla()
        {
            string userID = User.Identity.GetUserId();
            IEnumerable<Sepet> sepetUrunleri = DatabaseContext.Sepets.Where(a => a.RefAspNetUserID == userID).ToList();

            string ClientId = "100300000"; // Bankadan aldığınız mağaza kodu
            string Amount = sepetUrunleri.Sum(a => a.ToplamTutar).ToString(); // sepettteki ürünlerin toplam fiyatı
            string Oid = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now); // sipariş id oluşturuyoruz. her sipariş için farklı olmak zorunda
            string OnayURL = "http://localhost:49554/Siparis/Tamamlandi"; // Ödeme tamamlandığında bankadan verilerin geleceği url
            string HataURL = "http://localhost:49554/Siparis/Hatali"; // Ödeme hata verdiğinde bankadan gelen verilerin gideceği url
            string RDN = "asdf"; // hash karşılaştırması için eklenen rast gele dizedir
            string StoreKey = "123456"; // Güvenlik anahtarı bankanın sanal pos sayfasından alıyoruz


            string TransActionType = "Auth"; // bu bölüm sabit değişmiyor
            string Instalment = "";
            string HashStr = ClientId + Oid + Amount + OnayURL + HataURL + TransActionType + Instalment + RDN + StoreKey; // Hash oluşturmak için bankanın bizden istediği stringleri birleştiriyoruz

            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] HashBytes = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(HashStr);
            byte[] InputBytes = sha.ComputeHash(HashBytes);
            string Hash = Convert.ToBase64String(InputBytes);

            ViewBag.ClientId = ClientId;
            ViewBag.Oid = Oid;
            ViewBag.okUrl = OnayURL;
            ViewBag.failUrl = HataURL;
            ViewBag.TransActionType = TransActionType;
            ViewBag.RDN = RDN;
            ViewBag.Hash = Hash;
            ViewBag.Amount = Amount;
            ViewBag.StoreType = "3d_pay_hosting"; // Ödeme modelimiz biz buna göre anlatıyoruz 
            ViewBag.Description = "";
            ViewBag.XID = "";
            ViewBag.Lang = "tr";
            ViewBag.EMail = "destek@karayeltasarim.com";
            ViewBag.UserID = "karayelapi"; // bu id yi bankanın sanala pos ekranında biz oluşturuyoruz.
            ViewBag.PostURL = "https://entegrasyon.asseco-see.com.tr/fim/est3Dgate";


            return View();
        }


        public ActionResult Tamamlandi()
        {
            string userID = User.Identity.GetUserId();

            Sipari siparis = new Sipari()
            {
                Ad = Request.Form.Get("Ad"),
                Soyad = Request.Form.Get("Soyad"),
                Adres = Request.Form.Get("Adres"),
                Tarih = DateTime.Now,
                TcKimlikNo = Request.Form.Get("TCKimlikNo"),
                Telefon = Request.Form.Get("Telefon"),
                RefAspNetUserID = userID,
                RefKargoID=1
            };

            IEnumerable<Sepet> sepettekiUrunler = DatabaseContext.Sepets.Where(a => a.RefAspNetUserID == userID).ToList();

            foreach (Sepet sepetUrunu in sepettekiUrunler)
            {
                SiparisKalem yeniKalem = new SiparisKalem()
                {
                    Adet = sepetUrunu.Adet,
                    ToplamTutar = sepetUrunu.ToplamTutar,
                    RefUrunID = sepetUrunu.RefUrunId
                    
                };

                siparis.SiparisKalems.Add(yeniKalem);

                DatabaseContext.Sepets.Remove(sepetUrunu);
            }

            DatabaseContext.Siparis.Add(siparis);
            DatabaseContext.SaveChanges();

            return View();
        }

        public ActionResult Hatali()
        {

            ViewBag.Hata = Request.Form;

            return View();
        }
    }
}