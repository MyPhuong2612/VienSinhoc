//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDoAnVienSinhHoc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTHoaDon
    {
        public int MaCT { get; set; }
        public Nullable<int> MaHD { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> MaSP { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
