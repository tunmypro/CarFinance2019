//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class loan : loanc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public loan()
        {
            this.receipt = new HashSet<receipt>();
        }
    
        public int loancode { get; set; }
        public string loanmem { get; set; }
        public Nullable<decimal> loanmoney { get; set; }
        public Nullable<System.DateTime> loandate { get; set; }
        public Nullable<int> loanmonth { get; set; }
        public Nullable<int> loancar { get; set; }
        public Nullable<double> loaninterest { get; set; }
        public Nullable<decimal> loadpermonth { get; set; }
        public Nullable<System.DateTime> loanlastdate { get; set; }
    
        public virtual gen gen { get; set; }
        public virtual member member { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<receipt> receipt { get; set; }
    }
}
