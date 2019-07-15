using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using APICarFinance;

namespace WebCarFinance.Controllers
{
    public class View_CustomerController : Controller
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: View_Customer
        public ActionResult Index()
        {
            return View(db.View_Customer.ToList());
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public ActionResult View_Customers()
        {
            var loan = db.loan.ToList();
            List<loan> listloan = new List<loan>();
            foreach (var item in loan)
            {
                if (GetMonthDifference(item.loanlastdate.Value, DateTime.UtcNow) > 0)
                {
                    item.month = GetMonthDifference(item.loanlastdate.Value, DateTime.UtcNow);
                    item.totalmonth = GetMonthDifference(item.loanlastdate.Value, DateTime.UtcNow) * item.loadpermonth;
                    listloan.Add(item);
                }
            }
            return View(listloan);
        }

        public void sendcustomers()
        {
            var loan = db.loan.ToList();
            List<loan> listloan = new List<loan>();
            string linetext1 = Environment.NewLine + "ชื่อ - สกุล            เบอร์โทร";
            string linetext2 = Environment.NewLine + "บุคคลค้างชำระประจำวันที่" + "  " + DateTime.UtcNow.ToShortDateString();
            foreach (var item in loan)
            {
                if (GetMonthDifference(item.loanlastdate.Value, DateTime.UtcNow) > 0)
                {
                    item.month = GetMonthDifference(item.loanlastdate.Value, DateTime.UtcNow);
                    item.totalmonth = GetMonthDifference(item.loanlastdate.Value, DateTime.UtcNow) * item.loadpermonth;
                    listloan.Add(item);
                    linetext2 = linetext2 + Environment.NewLine +
                                item.member.memname + " " + item.member.memlname + " " + item.member.memtel;
                }
            }
            lineNotify(linetext1, linetext2);
            RedirectToAction("View_Customers", "View_Customer");
        }

        private void lineNotify(string msg1, string msg2)
        {
            string token = "84SuHOiSXxU5P8opL5F3it2RJCChUNHJ3Yd4iIQKmx8";
            try
            {
                string summsg = msg1 + msg2;
                var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");
                var postData = string.Format("message={0}", summsg);
                var data = Encoding.UTF8.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.Headers.Add("Authorization", "Bearer " + token);

                using (var stream = request.GetRequestStream()) stream.Write(data, 0, data.Length);
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // GET: View_Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_Customer view_Customer = db.View_Customer.Find(id);
            if (view_Customer == null)
            {
                return HttpNotFound();
            }
            return View(view_Customer);
        }

        public ActionResult Shows(string name)
        {
            View_Customer view_Customer = db.View_Customer.Where(x => x.memname == name).FirstOrDefault();
            if (view_Customer == null)
            {
                Session["alert"] = "ไม่พบข้อมูลการกู้";
                return RedirectToAction("Details", "members", new { id = Session["Userid"] });
            }
            return View(view_Customer);
        }

        // GET: View_Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult getname(string name, string lname)
        {
            var idcard = db.member.Where(x => x.memname == name && x.memlname == lname).FirstOrDefault().memidcard;
            Session["idcardgetname"] = idcard;
            return RedirectToAction("Create", "receipts", new { idcard = idcard });
        }

        // POST: View_Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "loancode,memname,memlname,memtel,loanmoney,loanmonth,loadpermonth,carbrand,genname")] View_Customer view_Customer)
        {
            if (ModelState.IsValid)
            {
                db.View_Customer.Add(view_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view_Customer);
        }

        // GET: View_Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_Customer view_Customer = db.View_Customer.Find(id);
            if (view_Customer == null)
            {
                return HttpNotFound();
            }
            return View(view_Customer);
        }

        // POST: View_Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "loancode,memname,memlname,memtel,loanmoney,loanmonth,loadpermonth,carbrand,genname")] View_Customer view_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(view_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(view_Customer);
        }

        // GET: View_Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_Customer view_Customer = db.View_Customer.Find(id);
            if (view_Customer == null)
            {
                return HttpNotFound();
            }
            return View(view_Customer);
        }

        // POST: View_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            View_Customer view_Customer = db.View_Customer.Find(id);
            db.View_Customer.Remove(view_Customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
