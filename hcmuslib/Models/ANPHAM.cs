//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ANPHAM
    {
        public ANPHAM()
        {
            this.BM_CHUONGTAPCHI = new HashSet<BM_CHUONGTAPCHI>();
            this.BM_KYTAPCHI = new HashSet<BM_KYTAPCHI>();
        }
    
        public int ID_ANPHAM { get; set; }
        public string TEN_ANPHAM { get; set; }
        public string TONGBT { get; set; }
        public string CQ_CHUQUAN { get; set; }
        public string DC_TOASOAN { get; set; }
        public Nullable<int> DKXB { get; set; }
        public string NXB { get; set; }
        public string SOPHANLOAI { get; set; }
    
        public virtual BMNXB BMNXB { get; set; }
        public virtual BMSOPHANLOAI BMSOPHANLOAI { get; set; }
        public virtual BMTACGIA BMTACGIA { get; set; }
        public virtual ICollection<BM_CHUONGTAPCHI> BM_CHUONGTAPCHI { get; set; }
        public virtual ICollection<BM_KYTAPCHI> BM_KYTAPCHI { get; set; }
    }
}
