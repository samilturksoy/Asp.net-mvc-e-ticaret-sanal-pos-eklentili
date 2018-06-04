using Starkk.Areas.Admin.Models;
using Starkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Starkk.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : AnaController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var data = new HomePageViewModel()
            {
                siparis = DatabaseContext.Siparis.Count(),
                urunler=DatabaseContext.Urunlers.Count(),
                uye=DatabaseContext.AspNetUsers.Count(),
                yazi=DatabaseContext.BlogYazis.Count()

            };
            return View(data);
        }
    }
}