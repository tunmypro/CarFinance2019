using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICarFinance
{
    public partial class V_car
    {
        //car
        [Display(Name = "รหัสรถยนต์")]
        public int carcode { get; set; }

        [Display(Name = "แบรนรถยนต์")]
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public string carbrand { get; set; }
    }
    [MetadataType(typeof(V_car))]
    public partial class car { }

    public partial class V_gen
    {
        //gen
        [Display(Name = "รหัสรุ่นรถยนต์")]
        public int gencode { get; set; }

        [Display(Name = "รุ่นรถยนต์")]
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public string genname { get; set; }

        [Display(Name = "ปี")]
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public string genyear { get; set; }

        [Display(Name = "ราคารถยนต์")]
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public Nullable<decimal> gencost { get; set; }

        [Display(Name = "รายละเอียดรถยนต์")]
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public string gendetail { get; set; }

        public Nullable<int> gencar { get; set; }
    }
    [MetadataType(typeof(V_gen))]
    public partial class gen { }

    public partial class V_loan
    {
        //loan
        [Display(Name = "รหัสสัญญา")]
        public int loancode { get; set; }

        [Display(Name = "รหัสบัตรประชาชนคนกู้")]
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public string loanmem { get; set; }

        [Display(Name = "จำนวนเงินกู้")]
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public Nullable<decimal> loanmoney { get; set; }

        [Display(Name = "วันที่กู้")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> loandate { get; set; }

        [Display(Name = "จำนวนเดือน")]
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public Nullable<int> loanmonth { get; set; }

        [Display(Name = "รุ่นรถยนต์")]
        public Nullable<int> loancar { get; set; }

        [Display(Name = "จำนวนดอกเบี้ย")]
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public Nullable<double> loaninterest { get; set; }

        [Display(Name = "จำนวนจ่ายต่อเดือน")]
        public Nullable<decimal> loadpermonth { get; set; }

        [Display(Name = "วันล่าสุดที่จ่าย")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> loanlastdate { get; set; }
    }
    [MetadataType(typeof(V_loan))]
    public partial class loan : loanc { }

    public partial class V_login
    {
        //login
        [Display(Name = "รหัสไอดี")]
        public int logcode { get; set; }

        [Display(Name = "รหัสบัตรประชาชน")]
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public string logmem { get; set; }

        [Display(Name = "ไอดี")]
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public string loguser { get; set; }

        [Display(Name = "รหัสผ่าน")]
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public string logpass { get; set; }

        [Display(Name = "ประเภทผู้ใช้งาน")]
        public Nullable<int> logtype { get; set; }
    }
    [MetadataType(typeof(V_login))]
    public partial class login : ViewData { }

    public partial class V_member
    {
        //member
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [Display(Name = "รหัสบัตรประชาชน")]
        [StringLength(13, ErrorMessage = "กรุณาใส่แค่ 13 หลัก"), MinLength(13, ErrorMessage = "กรุณาใส่ให้ครบ 13 หลัก")]
        [RegularExpression("([0-9]+)", ErrorMessage = "กรุณากรอกเฉพาะตัวเลข")]
        public string memidcard { get; set; }

        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [Display(Name = "ชื่อ")]
        public string memname { get; set; }

        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [Display(Name = "นามสกุล")]
        public string memlname { get; set; }

        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [Display(Name = "อายุ")]
        public Nullable<int> memage { get; set; }

        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [Display(Name = "อาชีพ")]
        public string memcareer { get; set; }

        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [Display(Name = "เงินเดือน")]
        public Nullable<decimal> memincome { get; set; }

        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [Display(Name = "เบอร์โทร")]
        public string memtel { get; set; }

        [Display(Name = "ไลน์")]
        public string memline { get; set; }
    }
    [MetadataType(typeof(V_member))]
    public partial class member { }

    public partial class V_receipt
    {
        //receipt
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [Display(Name = "รหัสใบเสร็จ")]
        public string recode { get; set; }

        [Display(Name = "รหัสบัตรประชาชน")]
        public Nullable<int> reloan { get; set; }
        [Display(Name = "วันที่ทำรายการ")]
        public Nullable<System.DateTime> redate { get; set; }

        [Display(Name = "จำนวนเงินที่ต้องจ่าย")]
        public Nullable<decimal> remoney { get; set; }

        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [Display(Name = "จำนวนเงินที่รับ")]
        public Nullable<decimal> rerecive { get; set; }

        [Display(Name = "จำนวนเงินทอน")]
        public Nullable<decimal> rechange { get; set; }

        [Display(Name = "ชื่อผู้ทำรายการ")]
        public string remem { get; set; }
    }
    [MetadataType(typeof(V_receipt))]
    public partial class receipt { }

    public partial class V_View_Car
    {
        public int gencode { get; set; }
        public string carbrand { get; set; }
        public string genname { get; set; }
        public string genyear { get; set; }
        public Nullable<decimal> gencost { get; set; }
        public string gendetail { get; set; }
    }
    [MetadataType(typeof(V_View_Car))]
    public partial class View_Car : SelectlistViewModel { }
}
