//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cafe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Checks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Checks()
        {
            this.Purchases = new HashSet<Purchases>();
        }
    
        public long CheckID { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public decimal CostNDiscount { get; set; }
        public bool IsComplexLunch { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchases> Purchases { get; set; }
    }
}
