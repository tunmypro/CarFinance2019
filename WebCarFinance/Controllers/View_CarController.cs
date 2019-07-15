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
    public class View_CarController : Controller
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: View_Car
        public ActionResult Index()
        {
            List<car> carlist = db.car.ToList();
            ViewBag.carlist = new SelectList(carlist, "carcode", "carbrand");
            return View(db.View_Car.ToList());
        }

        public ActionResult selectlist1(int CarID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<gen> genlist = db.gen.Where(x => x.gencar == CarID).ToList();
            return Json(genlist, JsonRequestBehavior.AllowGet);
        }

        // GET: View_Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) id = 8;
            List<car> carlist = db.car.ToList();
            ViewBag.carlist = new SelectList(carlist, "carcode", "carbrand");
            View_Car view_Car = db.View_Car.Find(id);
            List<int> list = new List<int>();
            ViewData["car"] = view_Car;
            return View(view_Car);
        }

        // GET: View_Car/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: View_Car/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "gencode,carbrand,genname,genyear,gencost,gendetail")] View_Car view_Car)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.View_Car.Add(view_Car);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(view_Car);
        //}

        //// GET: View_Car/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    View_Car view_Car = db.View_Car.Find(id);
        //    if (view_Car == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(view_Car);
        //}

        //// POST: View_Car/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "gencode,carbrand,genname,genyear,gencost,gendetail")] View_Car view_Car)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(view_Car).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(view_Car);
        //}

        //// GET: View_Car/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    View_Car view_Car = db.View_Car.Find(id);
        //    if (view_Car == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(view_Car);
        //}

        //// POST: View_Car/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    View_Car view_Car = db.View_Car.Find(id);
        //    db.View_Car.Remove(view_Car);
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
