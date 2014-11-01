//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class SACH
    {
        public SACH()
        {
            this.LUUHANHSACH = new HashSet<LUUHANHSACH>();
            this.MUONTAICHO = new HashSet<MUONTAICHO>();
        }
    
        public string ID_SACH { get; set; }
        public Nullable<System.DateTime> NGAY_NHAP { get; set; }
        public string NHAN_DE_CHINH { get; set; }
        public string TAC_GIA { get; set; }
        public string NHA_XUAT_BAN { get; set; }
        public string SO_PHAN_LOAI { get; set; }
        public string TEN_DE_MUC { get; set; }
        public string NHAN_DE_SONG_SONG { get; set; }
        public string NHAN_DE_KHAC { get; set; }
        public Nullable<System.DateTime> NAM_XUAT_BAN { get; set; }
        public string MA_VACH { get; set; }
        public Nullable<int> LAN_XUAT_BAN { get; set; }
        public string NOI_XUAT_BAN { get; set; }
        public Nullable<int> SO_TRANG_DAU { get; set; }
        public string NOI_DUNG { get; set; }
        public string MINH_HOA { get; set; }
        public string KHO_SACH { get; set; }
        public string TUNG_THU { get; set; }
        public string NGON_NGU { get; set; }
        public string ISBN { get; set; }
        public string BAN_QUYEN { get; set; }
        public string GHI_CHU { get; set; }
    
        public virtual BMNXB BMNXB { get; set; }
        public virtual BMNHANDECHINH BMNHANDECHINH { get; set; }
        public virtual BMSOPHANLOAI BMSOPHANLOAI { get; set; }
        public virtual BMTACGIA BMTACGIA { get; set; }
        public virtual BMTENDEMUC BMTENDEMUC { get; set; }
        public virtual ICollection<LUUHANHSACH> LUUHANHSACH { get; set; }
        public virtual ICollection<MUONTAICHO> MUONTAICHO { get; set; }
    }
}