﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hcmuslib.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLTHUVIENEntities : DbContext
    {
        public QLTHUVIENEntities()
            : base("name=QLTHUVIENEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BMNXB> BMNXB { get; set; }
        public DbSet<BMNHANDECHINH> BMNHANDECHINH { get; set; }
        public DbSet<BMSOPHANLOAI> BMSOPHANLOAI { get; set; }
        public DbSet<BMTACGIA> BMTACGIA { get; set; }
        public DbSet<BMTENDEMUC> BMTENDEMUC { get; set; }
        public DbSet<BOITHUONGTHIETHAI> BOITHUONGTHIETHAI { get; set; }
        public DbSet<DOCGIA> DOCGIA { get; set; }
        public DbSet<DONHANG> DONHANG { get; set; }
        public DbSet<LEARNCOMMONS> LEARNCOMMONS { get; set; }
        public DbSet<LUUHANHSACH> LUUHANHSACH { get; set; }
        public DbSet<MUONPHONG> MUONPHONG { get; set; }
        public DbSet<MUONTAICHO> MUONTAICHO { get; set; }
        public DbSet<NHANVIEN> NHANVIEN { get; set; }
        public DbSet<PHONG> PHONG { get; set; }
        public DbSet<SACH> SACH { get; set; }
        public DbSet<TAPHUAN> TAPHUAN { get; set; }
        public DbSet<THIETBI_DICHVU> THIETBI_DICHVU { get; set; }
        public DbSet<USER_PASSWORD> USER_PASSWORD { get; set; }
        public DbSet<CT_DONHANG> CT_DONHANG { get; set; }
        //public DbSet<DKTAPHUAN> DKTAPHUANs { get; set; }
    }
}
