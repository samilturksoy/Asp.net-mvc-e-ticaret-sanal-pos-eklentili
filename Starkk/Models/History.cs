//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Starkk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class History
    {
        public int Id { get; set; }
        public string Aciklama { get; set; }
        public byte[] Resim { get; set; }
        public string Tarih { get; set; }

        [NotMapped]
        public HttpPostedFileBase ResimFile { get; set; }
    }
}
