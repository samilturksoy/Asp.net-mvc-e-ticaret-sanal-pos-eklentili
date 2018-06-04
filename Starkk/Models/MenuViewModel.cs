using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Starkk.Models
{
    public  class MenuViewModel
    {
        public List<Kategori> kategori { get; set; }
        public List<Urunler> urun { get; set; }
    }
}