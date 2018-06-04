using Starkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Starkk.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UyeController : AnaController
    {
        // GET: Admin/Uye
        public ActionResult Index()
        {
            return View(DatabaseContext.AspNetUsers.ToList());
        }
    }
}