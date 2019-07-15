using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APICarFinance;
using WebCarFinance.Models;
using ViewData = WebCarFinance.Models.ViewData;

namespace WebCarFinance.Controllers
{
    public class loginsController : Controller
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: logins
        public ActionResult Index()
        {
            ViewBag.Readonly = false;
            return View();
        }

        [HttpPost]
        public ActionResult Index(login login)
        {
            if (login.loguser != null && login.logpass != null)
            {
                var n = db.login.Where(x => x.loguser == login.loguser && x.logpass == login.logpass).FirstOrDefault();
                if (n != null)
                {
                    Session["User"] = n.member.memname;
                    Session["Userid"] = n.member.memidcard;
                    Session["Pass"] = n;
                    if (n.logtype == 1 || n.logtype == 2) Session["pay"] = "set";
                    return RedirectToAction("UserCheck");
                }
                else
                {
                    ViewBag.alert = "ข้อมูลไม่ถูกต้อง";
                    return View(login);
                }
            }
            return RedirectToAction("UserCheck");
        }

        public ActionResult UserCheck()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("UserCheck");
        }

        // GET: logins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            login login = db.login.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // GET: logins/Create
        public ActionResult Create()
        {
            if (Session["memlist"] != null)
            {
                ViewData objlt = (ViewData)Session["memlist"];
                member members = new member();
                members = objlt.Members;
                ViewBag.idcard = members.memidcard;
                ViewBag.Readonly = true;
            }
            else ViewBag.Readonly = false;

            ViewBag.logmem = new SelectList(db.member, "memidcard", "memname");
            ViewBag.logtype = new SelectList(db.type, "typecode", "typename");
            return View();
        }

        // POST: logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(login login)
        {
            if (Session["memlist"] != null)
            {
                if (login.passwordcheck == login.logpass)
                {
                    ViewData objlt = (ViewData)Session["memlist"];
                    member members = new member();
                    members = objlt.Members;
                    

                    var chkidcard = db.member.Where(x => x.memidcard == members.memidcard).FirstOrDefault().memidcard;
                    var chkidcard1 = db.login.Where(x => x.logmem == members.memidcard).FirstOrDefault();
                    var chkusername = db.login.Where(x => x.loguser == login.loguser).FirstOrDefault().loguser;
                    try
                    {
                        if (chkidcard1 != null)
                        {
                            ViewBag.Readonly = false;
                            ModelState.AddModelError("logmem", "รหัสบัตรประชาชนนี้เคยสมัครใช้งานแล้ว");
                            return View(login);
                        }

                        if (chkusername != null)
                        {
                            ViewBag.Readonly = false;
                            ModelState.AddModelError("loguser", "มีชื่อผู้ใช้นี้ในระบบแล้ว");
                            return View(login);
                        }
                    }
                    catch (Exception e)
                    {
                        ViewBag.Readonly = false;
                        ModelState.AddModelError("loguser", "มีชื่อผู้ใช้นี้ในระบบแล้ว");
                        return View(login);
                    }
                    if (chkidcard != null)
                    {
                        login.logmem = chkidcard;

                        if (login.specialcode == "admin")
                        {
                            login.logtype = 1;
                        }
                        else if (login.specialcode == "emp")
                        {
                            login.logtype = 2;
                        }
                        else login.logtype = 3;

                        db.login.Add(login);
                        db.SaveChanges();
                        Session.Remove("memlist");
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.Readonly = false;
                    ModelState.AddModelError("logpass", "กรุณาใส่รหัสผ่านให้เหมือนกัน!");
                    ModelState.AddModelError("passwordcheck", "กรุณาใส่รหัสผ่านให้เหมือนกัน!");
                }
            }
            else
            {
                if (login.passwordcheck == login.logpass)
                {
                    var chkidcard1 = db.member.Where(x => x.memidcard == login.logmem).FirstOrDefault();
                    var chkidcard2 = db.login.Where(x => x.logmem == login.logmem).FirstOrDefault();
                    if (chkidcard1 != null && chkidcard2 == null)
                    {
                        var chkusername = db.login.Where(x => x.loguser == login.loguser).FirstOrDefault();

                        if (chkusername != null)
                        {
                            ViewBag.Readonly = false;
                            ModelState.AddModelError("loguser", "มีชื่อผู้ใช้นี้ในระบบแล้ว");
                            return View(login);
                        }

                        if (login.specialcode == "admin")
                        {
                            login.logtype = 1;
                        }
                        else if (login.specialcode == "emp")
                        {
                            login.logtype = 2;
                        }
                        else login.logtype = 3;

                        db.login.Add(login);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else if (chkidcard2 != null)
                    {
                        ViewBag.Readonly = false;
                        ModelState.AddModelError("logmem", "รหัสบัตรประชาชนนี้เคยสมัครใช้งานแล้ว");
                        return View(login);
                    }
                    else
                    {
                        ViewBag.Readonly = false;
                        ModelState.AddModelError("logmem", "ไม่มีรหัสบัตรประชาชนนี้ในระบบ กรุณากลับไปสมัคร");
                        return View(login);
                    }
                }
                else
                {
                    ViewBag.Readonly = false;
                    ModelState.AddModelError("logpass", "กรุณาใส่รหัสผ่านให้เหมือนกัน!");
                    ModelState.AddModelError("passwordcheck", "กรุณาใส่รหัสผ่านให้เหมือนกัน!");
                }
            }
            ViewBag.logmem = new SelectList(db.member, "memidcard", "memname", login.logmem);
            ViewBag.logtype = new SelectList(db.type, "typecode", "typename", login.logtype);
            return View(login);
        }


        // GET: logins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            login login = db.login.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            ViewBag.logmem = new SelectList(db.member, "memidcard", "memname", login.logmem);
            ViewBag.logtype = new SelectList(db.type, "typecode", "typename", login.logtype);
            return View(login);
        }

        // POST: logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "logcode,logmem,loguser,logpass,logtype")] login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.logmem = new SelectList(db.member, "memidcard", "memname", login.logmem);
            ViewBag.logtype = new SelectList(db.type, "typecode", "typename", login.logtype);
            return View(login);
        }

        // GET: logins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            login login = db.login.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            login login = db.login.Find(id);
            db.login.Remove(login);
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
