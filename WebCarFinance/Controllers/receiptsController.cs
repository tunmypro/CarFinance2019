using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using APICarFinance;

namespace WebCarFinance.Controllers
{
    public class receiptsController : Controller
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: receipts
        public ActionResult Index()
        {
            var receipt = db.receipt.Include(r => r.loan);
            return View(receipt.ToList());
        }

        // GET: receipts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receipt receipt = db.receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // GET: receipts/Create
        public ActionResult Create(string idcard)
        {
            if (idcard != null)
            {
                int findloancode = db.loan.Where(x => x.loanmem == idcard).FirstOrDefault().loancode;
                ViewBag.loancode = findloancode;
                var loanmonth = db.loan.Where(x => x.loancode == findloancode).FirstOrDefault().loanmonth;
                ViewBag.permonth = db.loan.Where(x => x.loancode == findloancode).FirstOrDefault().loadpermonth;
                List<int> listmonth = new List<int>();
                for (int i = 1; i <= loanmonth; i++)
                {
                    listmonth.Add(i);
                }
                ViewBag.loanmonth = listmonth;
            }
            else return RedirectToAction("Index", "View_Customer");
            return View();
        }

        public void getmonth(string month)
        {
            Session["monthleft"] = month;
        }
        // POST: receipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(receipt receipt)
        {
            if (Session["monthleft"] == null)
            {
                Session["monthleft"] = 1;
            }
            var loans = db.loan.Where(x => x.loancode == receipt.reloan).FirstOrDefault();
            if (receipt.rerecive - (loans.loadpermonth * Convert.ToInt32(Session["monthleft"])) >= 0)
            {
                if (Convert.ToInt32(Session["monthleft"]) == 1)
                {
                    loans.loanmonth = loans.loanmonth - 1;
                }
                else
                {
                    loans.loanmonth = loans.loanmonth - Convert.ToInt32(Session["monthleft"]);
                }
                loans.loanmoney = loans.loanmoney - (loans.loadpermonth * Convert.ToInt32(Session["monthleft"]));
                receipt.remoney = loans.loadpermonth * Convert.ToInt32(Session["monthleft"]);
                var date = DateTime.Now;
                receipt.recode = date.Day.ToString() + date.Month.ToString() + receipt.reloan.ToString() + db.receipt.Count().ToString();
                receipt.redate = DateTime.UtcNow;
                receipt.rechange = receipt.rerecive - receipt.remoney;
                receipt.remem = Session["User"].ToString();
                loans.loanlastdate = DateTime.UtcNow;
                In_Ex income = new In_Ex();
                income.expenditure = 0;
                income.income = receipt.remoney;
                income.date = DateTime.UtcNow;
                db.In_Ex.Add(income);
                db.receipt.Add(receipt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.reloan = new SelectList(db.loan, "loancode", "loanmem", receipt.reloan);
            return RedirectToAction("Create", "receipts", new { idcard = Session["idcardgetname"] });
        }

        // GET: receipts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receipt receipt = db.receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            ViewBag.reloan = new SelectList(db.loan, "loancode", "loanmem", receipt.reloan);
            return View(receipt);
        }

        // POST: receipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recode,reloan,redate,remoney,rerecive,rechange,remem")] receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.reloan = new SelectList(db.loan, "loancode", "loanmem", receipt.reloan);
            return View(receipt);
        }

        // GET: receipts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receipt receipt = db.receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // POST: receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            receipt receipt = db.receipt.Find(id);
            db.receipt.Remove(receipt);
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
