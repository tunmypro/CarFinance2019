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
    public class membersController : Controller
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: members
        public ActionResult Index()
        {
            return View(db.member.ToList());
        }

        // GET: members/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            if (Session["alert"] != null)
            {
                ViewBag.alert = "ไม่พบข้อมูลการกู้";
                Session.Remove("alert");
            }
            return View(member);
        }

        // GET: members/Create
        public ActionResult Create()
        {
            Session.Remove("memlist");
            return View();
        }

        // POST: members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(member member)
        {
            if (ModelState.IsValid)
            {
                Session.Remove("memlist");
                ViewData obj = new ViewData();
                obj.Members = new member();
                obj.Members = member;
                Session["memlist"] = obj;
                db.member.Add(member);
                db.SaveChanges();

                return RedirectToAction("Create", "logins");
            }

            return View(member);
        }

        // GET: members/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "memidcard,memname,memlname,memage,memcareer,memincome,memtel,memline")] member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details",new {id = member.memidcard});
            }
            return View(member);
        }

        // GET: members/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            member member = db.member.Find(id);
            db.member.Remove(member);
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
