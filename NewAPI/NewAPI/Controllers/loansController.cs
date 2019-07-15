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
using NewAPI.Models;

namespace NewAPI.Controllers
{
    public class loansController : ApiController
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: api/loans
        public IQueryable<loan> Getloan()
        {
            return db.loan;
        }

        // GET: api/loans/5
        [ResponseType(typeof(loan))]
        public IHttpActionResult Getloan(int id)
        {
            loan loan = db.loan.Find(id);
            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        // PUT: api/loans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putloan(int id, loan loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loan.loancode)
            {
                return BadRequest();
            }

            db.Entry(loan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!loanExists(id))
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

        // POST: api/loans
        [ResponseType(typeof(loan))]
        public IHttpActionResult Postloan(loan loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.loan.Add(loan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = loan.loancode }, loan);
        }

        // DELETE: api/loans/5
        [ResponseType(typeof(loan))]
        public IHttpActionResult Deleteloan(int id)
        {
            loan loan = db.loan.Find(id);
            if (loan == null)
            {
                return NotFound();
            }

            db.loan.Remove(loan);
            db.SaveChanges();

            return Ok(loan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool loanExists(int id)
        {
            return db.loan.Count(e => e.loancode == id) > 0;
        }
    }
}