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
    
    public partial class Huyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Huyen()
        {
            this.Xas = new HashSet<Xa>();
        }
    
        public int MaHuyen { get; set; }
        public string TenHuyen { get; set; }
        public Nullable<int> MaT { get; set; }
    
        public virtual Tinh Tinh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Xa> Xas { get; set; }
    }
}
