//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TOURDL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SPTOUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPTOUR()
        {
            this.HOADONs = new HashSet<HOADON>();
        }
    
        public string ID_SPTour { get; set; }
        public string TenSPTour { get; set; }
        public Nullable<int> GiaNguoiLon { get; set; }
        public Nullable<System.DateTime> NgayKhoiHanh { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public string MoTa { get; set; }
        public string DiemTapTrung { get; set; }
        public string DiemDen { get; set; }
        public Nullable<int> SoNguoi { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<int> GiaTreEm { get; set; }
        public Nullable<int> ID_NV { get; set; }
        public string ID_TOUR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual TOUR TOUR { get; set; }
    }
}
