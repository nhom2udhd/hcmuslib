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
    
    public partial class DONHANG
    {
        public string ID_DON_HANG { get; set; }
        public Nullable<System.DateTime> NGAY_LAP { get; set; }
        public string TINH_TRANG { get; set; }
        public string DIA_CHI_GOI { get; set; }
        public string HINH_THUC_THANH_TOAN { get; set; }
        public string DON_VI_TIEN_TE { get; set; }
        public Nullable<System.DateTime> NGAY_GIAO_HANG { get; set; }
        public Nullable<System.DateTime> NGAY_THANH_TOAN { get; set; }
    
        public virtual CT_DONHANG CT_DONHANG { get; set; }


    }
}
