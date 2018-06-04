using Starkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Starkk.Controllers
{
    public class HomeController : AnaController
    {
        public ActionResult Index()
        {
           
            
            return View(DatabaseContext.Sliders.OrderBy(p=>p.Sirasi).ToList());
        }

        public ActionResult About()
        {
            var aboutData = new AboutViewModel()
            {
                Gecmis = DatabaseContext.Histories.ToList(),
                Hakkimizda=DatabaseContext.Hakkimizdas.FirstOrDefault()


            };
            return View(aboutData);
        }

        public ActionResult Contact()
        {
            return View(DatabaseContext.Iletisims.FirstOrDefault());
        }

        //mail gönderme post


        [HttpPost]
        public ActionResult Contact(string email, string name, string kulmail, string message, string Telefon)
        {
            MailGonder("starkmsstc@gmail.com", name, kulmail, message, Telefon);
            return View(DatabaseContext.Iletisims.FirstOrDefault());
        }


        //mail gönderme metodu
        public void MailGonder(string email, string name, string kulmail, string message, string Telefon)
        {

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new MailAddress("starkmsstc@gmail.com");
            mail.To.Add(email);
            mail.IsBodyHtml = true;
            mail.Subject = "Yeni Mesaj";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.Body = "<h3> Yeni bir kullanıcı bilgi almak istiyor <h3/>"
                + "<b>İsim Soyisim<b/> : " + name +
                "<br/>"
                + "<b>Email <b/>: " + kulmail +
                "<br/>"
                  + "<b>Telefon <b/>: " + Telefon +
                "<br/>"
                + "<b>Mesajı <b/>: " + message;
            SmtpClient sc = new SmtpClient();
            sc.Host = "smtp.gmail.com";
            sc.Port = 587;
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential("starkmsstc@gmail.com", "Starkmss1905");
            sc.Send(mail);


        }


        [ChildActionOnly]
        public ActionResult Menu()
        {

            var pageModel = new MenuViewModel
            {
                
                kategori = DatabaseContext.Kategoris.OrderBy(p => p.Id).Take(4).ToList(),
                urun = DatabaseContext.Urunlers.ToList()


            };

            return View(pageModel);
        }


        //childactionOnly footer Contact
        public ActionResult Footer()
        {

            

            return View(DatabaseContext.Iletisims.FirstOrDefault());
        }



        //mesafeli ürün sözleşmesi


        public ActionResult MesafeUrun()
        {
            return View();
        }

        //sss
        public ActionResult SSS()
        {
            return View();
        }

    }
}