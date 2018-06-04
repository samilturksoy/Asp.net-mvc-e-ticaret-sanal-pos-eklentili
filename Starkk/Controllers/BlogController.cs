using PagedList;
using Starkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Starkk.Controllers
{
    public class BlogController : AnaController
    {
        // GET: Blog
        public ActionResult Index(int sayfa = 1)
        {
            return View(DatabaseContext.BlogYazis.OrderByDescending(p=>p.Id).ToPagedList(sayfa, 2));
        }

        [ChildActionOnly]
        public ActionResult AnasayfaBlogYaziGetir()
        {
            return View(DatabaseContext.BlogYazis.OrderByDescending(p=>p.Id).ToList());
        }

        public ActionResult BlogDetay(int id)
        {
            return View(DatabaseContext.BlogYazis.Find(id));
        }

    }
}