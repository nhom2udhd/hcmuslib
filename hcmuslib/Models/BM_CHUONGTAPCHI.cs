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
    
    public partial class BM_CHUONGTAPCHI
    {
        public int ID_CHUONG { get; set; }
        public string TEN_CHUONG { get; set; }
        public string NOI_DUNG { get; set; }
        public Nullable<int> ANPHAM { get; set; }
    
        public virtual ANPHAM ANPHAM1 { get; set; }
    }
}