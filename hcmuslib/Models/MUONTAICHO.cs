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
    
    public partial class MUONTAICHO
    {
        public string ID_MUON_TC { get; set; }
        public string DOC_GIA { get; set; }
        public string ID_SACH { get; set; }
        public Nullable<System.DateTime> NGAY_MUON { get; set; }
        public string TINH_TRANG { get; set; }
    
        public virtual DOCGIA DOCGIA { get; set; }
        public virtual SACH SACH { get; set; }
    }
}
