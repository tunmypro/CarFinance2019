using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APICarFinance;
using WebCarFinance.Models;
using ViewData = WebCarFinance.Models.ViewData;

namespace WebCarFinance.Controllers
{
    public class carsController : Controller
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: cars
        public ActionResult Index()
        {
            List<car> carlist = db.car.ToList();
            ViewBag.carlist = new SelectList(carlist, "carcode", "carbrand");
            return View(carlist);
        }

        public ActionResult selectlist1(int CarID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<gen> genlist = db.gen.Where(x => x.gencar == CarID).ToList();
            return Json(genlist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult genselect(int GenID)
        {
            Session["cost"] = db.gen.Where(x => x.gencode == GenID).FirstOrDefault().gencost;
            return RedirectToAction("Index");
        }

        // GET: cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car car = db.car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: cars/Create
        public ActionResult Create()
        {
            ViewBag.cargen = new SelectList(db.gen, "gencode", "genname");
            return View();
        }

        // POST: cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(car car)
        {
            if (ModelState.IsValid)
            {
                db.car.Add(car);
                db.SaveChanges();
                return RedirectToAction("Create", "gens");
            }

            return View(car);
        }

        // GET: cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car car = db.car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            //ViewBag.cargen = new SelectList(db.gen, "gencode", "genname", car.cargen);
            return View(car);
        }

        // POST: cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "carcode,carbrand,cargen")] car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.cargen = new SelectList(db.gen, "gencode", "genname", car.cargen);
            return View(car);
        }

        // GET: cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car car = db.car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            car car = db.car.Find(id);
            db.car.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
