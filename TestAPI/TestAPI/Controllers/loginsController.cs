using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    public class loginsController : ApiController
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: api/logins
        public IQueryable<login> Getlogin()
        {
            return db.login;
        }

        [HttpPost, Route("api/loginapi")]
        public IHttpActionResult Login(login data)
        {
            var result = db.login.Where(x => x.loguser.Equals(data.loguser.Trim()) && x.logpass.Equals(data.logpass.Trim())).FirstOrDefault();
            if (result == null)
            {
                return BadRequest();
            }
            if (result != null)
            {
                var loan = db.loan.Where(x => x.loanmem.Equals(result.logmem.Trim())).FirstOrDefault();
                if (loan != null)
                {
                    var value = new
                    {
                        logcode = result.logcode,
                        logmem = result.logmem,
                        loguser = result.loguser,
                        logpass = result.logpass,
                        logtype = result.logtype,
                        memname = result.member.memname,
                        memlname = result.member.memlname,
                        memage = result.member.memage,
                        memcareer = result.member.memcareer,
                        memtel = result.member.memtel,
                        memline = result.member.memline,
                        loanmoney = string.Format("{0,12:0,000.00}", loan.loanmoney),
                        loanmonth = loan.loanmonth,
                        loadpermonth = string.Format("{0,12:0,000.00}", loan.loadpermonth)
                    };
                    return Json(value);
                }
                else
                {
                    var value = new
                    {
                        logcode = result.logcode,
                        logmem = result.logmem,
                        loguser = result.loguser,
                        logpass = result.logpass,
                        logtype = result.logtype,
                        memname = result.member.memname,
                        memlname = result.member.memlname,
                        memage = result.member.memage,
                        memcareer = result.member.memcareer,
                        memtel = result.member.memtel,
                        memline = result.member.memline,
                        loanmoney = "ไม่มีข้อมูล",
                        loanmonth = "ไม่มีข้อมูล",
                        loadpermonth = "ไม่มีข้อมูล"
                    };
                    return Json(value);
                }
            }
            return BadRequest();
        }

        // GET: api/logins/5
        [ResponseType(typeof(login))]
        public IHttpActionResult Getlogin(int id)
        {
            login login = db.login.Find(id);
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        // PUT: api/logins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putlogin(int id, login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != login.logcode)
            {
                return BadRequest();
            }

            db.Entry(login).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!loginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/logins
        [ResponseType(typeof(login))]
        public IHttpActionResult Postlogin(login login)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.login.Add(login);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = login.logcode }, login);
        }

        // DELETE: api/logins/5
        [ResponseType(typeof(login))]
        public IHttpActionResult Deletelogin(int id)
        {
            login login = db.login.Find(id);
            if (login == null)
            {
                return NotFound();
            }

            db.login.Remove(login);
            db.SaveChanges();

            return Ok(login);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool loginExists(int id)
        {
            return db.login.Count(e => e.logcode == id) > 0;
        }
    }
}