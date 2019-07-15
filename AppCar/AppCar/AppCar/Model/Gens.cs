using System;
using System.Collections.Generic;
using System.Text;

namespace AppCar.Model
{
    public class Gens
    {
        public int gencode { get; set; }
        public string genname { get; set; }
        public string genyear { get; set; }
        public Nullable<decimal> gencost { get; set; }
        public string gendetail { get; set; }
        public Nullable<int> gencar { get; set; }
    }
}
