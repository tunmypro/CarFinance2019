//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APICarFinance
{
    using System;
    using System.Collections.Generic;
    
    public partial class login : ViewData
    {
        public int logcode { get; set; }
        public string logmem { get; set; }
        public string loguser { get; set; }
        public string logpass { get; set; }
        public Nullable<int> logtype { get; set; }
    
        public virtual member member { get; set; }
        public virtual type type { get; set; }
    }
}
