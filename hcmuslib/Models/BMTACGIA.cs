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
    
    public partial class BMTACGIA
    {
        public BMTACGIA()
        {
            this.SACH = new HashSet<SACH>();
        }
    
        public string ID_TAC_GIA { get; set; }
        public string HO_TEN { get; set; }
        public string BUT_DANH { get; set; }
        public string THONG_TIN_BO_SUNG { get; set; }
        public string TINH_TRANG { get; set; }
    
        public virtual ICollection<SACH> SACH { get; set; }
    }
}
