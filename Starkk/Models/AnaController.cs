using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Starkk.Models
{
    public class AnaController : Controller
    {
        protected StarkmssEntities DatabaseContext = new StarkmssEntities();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                DatabaseContext.Dispose();
            base.Dispose(disposing);
        }
    }
}