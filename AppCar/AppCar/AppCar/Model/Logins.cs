using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppCarFinance.Model
{
    public class Logins
    {
        public string memname { get;set; }
        public string memlname { get;set; }
        public string memage { get;set; }
        public string memcareer { get;set; }
        public string memtel { get;set; }
        public string memline { get;set; }
        public int logcode { get; set; }
        public string logmem { get; set; }
        public string loguser { get; set; }
        public string logpass { get; set; }
        public Nullable<int> logtype { get; set; }
        public string loanmoney { get; set; }
        public string loanmonth { get; set; }
        public string loadpermonth { get; set; }
    }
}
