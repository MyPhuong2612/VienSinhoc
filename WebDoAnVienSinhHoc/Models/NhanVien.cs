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
    
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            this.HoaDons = new HashSet<HoaDon>();
            this.DuAns = new HashSet<DuAn>();
        }
    
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<decimal> Luong { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public Nullable<int> MaXa { get; set; }
        public Nullable<int> MaCV { get; set; }
        public Nullable<int> MaPB { get; set; }
        public string TenTK { get; set; }
    
        public virtual ChucVu ChucVu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual PhongBan PhongBan { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual Xa Xa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DuAn> DuAns { get; set; }
    }
}
