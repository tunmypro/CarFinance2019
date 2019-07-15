using System;
using System.Collections.Generic;
using System.Text;

namespace AppCarFinance.Model
{
    public class Logins
    {
        public int logcode { get; set; }
        public string logmem { get; set; }
        public string loguser { get; set; }
        public string logpass { get; set; }
        public Nullable<int> logtype { get; set; }
    }
}
