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
    
    public partial class BMNXB
    {
        public BMNXB()
        {
            this.ANPHAM = new HashSet<ANPHAM>();
            this.SACH = new HashSet<SACH>();
        }
    
        public string ID_NXB { get; set; }
        public string TEN_NXB { get; set; }
        public Nullable<System.DateTime> NGAY_THANH_LAP { get; set; }
        public string THONG_TIN_BO_SUNG { get; set; }
        public string TINH_TRANG { get; set; }
    
        public virtual ICollection<ANPHAM> ANPHAM { get; set; }
        public virtual ICollection<SACH> SACH { get; set; }
    }
}
