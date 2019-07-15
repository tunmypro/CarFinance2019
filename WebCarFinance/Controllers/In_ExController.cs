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
    public class In_ExController : Controller
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: In_Ex
        public ActionResult Index()
        {
            var sum = db.In_Ex;
            decimal? sumin = 0, sumex = 0;

            foreach (var item in sum)
            {
                sumin += item.income;
                sumex += item.expenditure;
            }

            ViewBag.sumin = string.Format("{0,12:0,000.00}", sumin);
            ViewBag.sumex = string.Format("{0,12:0,000.00}", sumex);
            ViewBag.total = string.Format("{0,12:0,000.00}", sumin-sumex);
            return View(db.In_Ex.ToList());
        }

        // GET: In_Ex/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    In_Ex in_Ex = db.In_Ex.Find(id);
        //    if (in_Ex == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(in_Ex);
        //}

        //// GET: In_Ex/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: In_Ex/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "no,income,expenditure,date")] In_Ex in_Ex)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.In_Ex.Add(in_Ex);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(in_Ex);
        //}

        //// GET: In_Ex/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    In_Ex in_Ex = db.In_Ex.Find(id);
        //    if (in_Ex == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(in_Ex);
        //}

        //// POST: In_Ex/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "no,income,expenditure,date")] In_Ex in_Ex)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(in_Ex).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(in_Ex);
        //}

        //// GET: In_Ex/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    In_Ex in_Ex = db.In_Ex.Find(id);
        //    if (in_Ex == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(in_Ex);
        //}

        //// POST: In_Ex/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    In_Ex in_Ex = db.In_Ex.Find(id);
        //    db.In_Ex.Remove(in_Ex);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
