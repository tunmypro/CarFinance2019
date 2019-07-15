using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APICarFinance;

namespace WebCarFinance.Controllers
{
    public class loansController : Controller
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: loans
        public ActionResult Index()
        {
            var loan = db.loan.Include(l => l.gen).Include(l => l.member);
            return View(loan.ToList());
        }

        // GET: loans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loan loan = db.loan.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // GET: loans/Create
        public ActionResult Create()
        {
            ViewBag.loancar = new SelectList(db.car, "carcode", "carbrand");
            ViewBag.loanmem = new SelectList(db.member, "memidcard", "memidcard");
            return View();
        }

        // POST: loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(loan loan)
        {
            if (ModelState.IsValid)
            {
                decimal? moneyin = loan.loanmoney * Convert.ToDecimal(loan.loaninterest);
                decimal? money = loan.loanmoney + moneyin / 100;
                loan.loadpermonth = money / loan.loanmonth;
                loan.loanmoney = money;
                loan.loandate = DateTime.UtcNow;
                loan.loanlastdate = DateTime.UtcNow;
                In_Ex expen = new In_Ex();
                expen.expenditure = money;
                expen.income = 0;
                expen.date = DateTime.UtcNow;
                db.In_Ex.Add(expen);
                db.loan.Add(loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.loancar = new SelectList(db.car, "carcode", "carbrand", loan.loancar);
            ViewBag.loanmem = new SelectList(db.member, "memidcard", "memidcard", loan.loanmem);
            return View(loan);
        }

        // GET: loans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loan loan = db.loan.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            ViewBag.loancar = new SelectList(db.car, "carcode", "carbrand", loan.loancar);
            ViewBag.loanmem = new SelectList(db.member, "memidcard", "memname", loan.loanmem);
            return View(loan);
        }

        // POST: loans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "loancode,loanmem,loanmoney,loandate,loanmonth,loancar,loaninterest")] loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.loancar = new SelectList(db.car, "carcode", "carbrand", loan.loancar);
            ViewBag.loanmem = new SelectList(db.member, "memidcard", "memname", loan.loanmem);
            return View(loan);
        }

        // GET: loans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loan loan = db.loan.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loan loan = db.loan.Find(id);
            db.loan.Remove(loan);
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

