//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public member()
        {
            this.loan = new HashSet<loan>();
            this.login = new HashSet<login>();
        }
    
        public string memidcard { get; set; }
        public string memname { get; set; }
        public string memlname { get; set; }
        public Nullable<int> memage { get; set; }
        public string memcareer { get; set; }
        public Nullable<decimal> memincome { get; set; }
        public string memtel { get; set; }
        public string memline { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<loan> loan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<login> login { get; set; }
    }
}
