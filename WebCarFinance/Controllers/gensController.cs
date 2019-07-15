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
    public class gensController : Controller
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: gens
        public ActionResult Index()
        {
            var gen = db.gen.Include(g => g.car);
            return View(gen.ToList());
        }

        // GET: gens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gen gen = db.gen.Find(id);
            if (gen == null)
            {
                return HttpNotFound();
            }
            return View(gen);
        }

        // GET: gens/Create
        public ActionResult Create()
        {
            ViewBag.gencar = new SelectList(db.car, "carcode", "carbrand");
            return View();
        }

        // POST: gens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(gen gen)
        {
            if (ModelState.IsValid)
            {
                db.gen.Add(gen);
                db.SaveChanges();
                return RedirectToAction("Index","View_Car");
            }

            ViewBag.gencar = new SelectList(db.car, "carcode", "carbrand", gen.gencar);
            return View(gen);
        }

        // GET: gens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gen gen = db.gen.Find(id);
            if (gen == null)
            {
                return HttpNotFound();
            }
            ViewBag.gencar = new SelectList(db.car, "carcode", "carbrand", gen.gencar);
            return View(gen);
        }

        // POST: gens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(gen gen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.gencar = new SelectList(db.car, "carcode", "carbrand", gen.gencar);
            return View(gen);
        }

        // GET: gens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gen gen = db.gen.Find(id);
            if (gen == null)
            {
                return HttpNotFound();
            }
            return View(gen);
        }

        // POST: gens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gen gen = db.gen.Find(id);
            db.gen.Remove(gen);
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
