﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StarkmssEntities : DbContext
    {
        public StarkmssEntities()
            : base("name=StarkmssEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Iletisim> Iletisims { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<ResimUrun> ResimUruns { get; set; }
        public virtual DbSet<Urunler> Urunlers { get; set; }
        public virtual DbSet<Kargo> Kargoes { get; set; }
        public virtual DbSet<BlogKategori> BlogKategoris { get; set; }
        public virtual DbSet<BlogYazi> BlogYazis { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Sepet> Sepets { get; set; }
        public virtual DbSet<Sipari> Siparis { get; set; }
        public virtual DbSet<SiparisKalem> SiparisKalems { get; set; }
        public virtual DbSet<Bayi> Bayis { get; set; }
        public virtual DbSet<Stok> Stoks { get; set; }
    }
}
