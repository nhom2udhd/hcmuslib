﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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
    
        public virtual DbSet<ANPHAM> ANPHAM { get; set; }
        public virtual DbSet<BM_CHUONGTAPCHI> BM_CHUONGTAPCHI { get; set; }
        public virtual DbSet<BM_KYTAPCHI> BM_KYTAPCHI { get; set; }
        public virtual DbSet<BMNXB> BMNXB { get; set; }
        public virtual DbSet<BMNHANDECHINH> BMNHANDECHINH { get; set; }
        public virtual DbSet<BMSOPHANLOAI> BMSOPHANLOAI { get; set; }
        public virtual DbSet<BMTACGIA> BMTACGIA { get; set; }
        public virtual DbSet<BMTENDEMUC> BMTENDEMUC { get; set; }
        public virtual DbSet<BOITHUONGTHIETHAI> BOITHUONGTHIETHAI { get; set; }
        public virtual DbSet<CT_DONHANG> CT_DONHANG { get; set; }
        public virtual DbSet<DKTAPHUAN> DKTAPHUAN { get; set; }
        public virtual DbSet<DOCGIA> DOCGIA { get; set; }
        public virtual DbSet<DONHANG> DONHANG { get; set; }
        public virtual DbSet<LEARNCOMMONS> LEARNCOMMONS { get; set; }
        public virtual DbSet<LUUHANHSACH> LUUHANHSACH { get; set; }
        public virtual DbSet<MUONPHONG> MUONPHONG { get; set; }
        public virtual DbSet<MUONTAICHO> MUONTAICHO { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<PHONG> PHONG { get; set; }
        public virtual DbSet<SACH> SACH { get; set; }
        public virtual DbSet<TAPHUAN> TAPHUAN { get; set; }
        public virtual DbSet<THIETBI_DICHVU> THIETBI_DICHVU { get; set; }
        public virtual DbSet<USER_PASSWORD> USER_PASSWORD { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<webpages_Membership> webpages_Membership { get; set; }
        public virtual DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public virtual DbSet<webpages_Roles> webpages_Roles { get; set; }
    }
}
