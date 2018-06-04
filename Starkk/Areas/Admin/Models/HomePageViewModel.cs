using Starkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Starkk.Areas.Admin.Models
{
    public class HomePageViewModel
    {
        public int urunler { get; set; }
        public int yazi { get; set; }

        public int siparis { get; set; }
        public int uye { get; set; }
    }
}