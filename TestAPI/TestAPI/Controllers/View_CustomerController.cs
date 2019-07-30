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
    public class View_CustomerController : ApiController
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: api/View_Customer
        public IQueryable<View_Customer> GetView_Customer()
        {
            return db.View_Customer;
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        [Route("api/stale")]
        public IList<loan> getstale()
        {
            var loan = db.loan.ToList();
            List<loan> listloan = new List<loan>();
            foreach (var item in loan)
            {
                if (GetMonthDifference(item.loanlastdate.Value, DateTime.UtcNow) > 0)
                {
                    item.month = GetMonthDifference(item.loanlastdate.Value, DateTime.UtcNow);
                    item.totalmonth = GetMonthDifference(item.loanlastdate.Value, DateTime.UtcNow) * item.loadpermonth;
                    item.memname = item.member.memname;
                    item.memlname = item.member.memlname;
                    item.memtel = item.member.memtel;
                    listloan.Add(item);
                }
            }
            return listloan;
        }

        // GET: api/View_Customer/5
        [ResponseType(typeof(View_Customer))]
        public IHttpActionResult GetView_Customer(int id)
        {
            View_Customer view_Customer = db.View_Customer.Find(id);
            if (view_Customer == null)
            {
                return NotFound();
            }

            return Ok(view_Customer);
        }

        // PUT: api/View_Customer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutView_Customer(int id, View_Customer view_Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != view_Customer.loancode)
            {
                return BadRequest();
            }

            db.Entry(view_Customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_CustomerExists(id))
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

        // POST: api/View_Customer
        [ResponseType(typeof(View_Customer))]
        public IHttpActionResult PostView_Customer(View_Customer view_Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.View_Customer.Add(view_Customer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (View_CustomerExists(view_Customer.loancode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = view_Customer.loancode }, view_Customer);
        }

        // DELETE: api/View_Customer/5
        [ResponseType(typeof(View_Customer))]
        public IHttpActionResult DeleteView_Customer(int id)
        {
            View_Customer view_Customer = db.View_Customer.Find(id);
            if (view_Customer == null)
            {
                return NotFound();
            }

            db.View_Customer.Remove(view_Customer);
            db.SaveChanges();

            return Ok(view_Customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool View_CustomerExists(int id)
        {
            return db.View_Customer.Count(e => e.loancode == id) > 0;
        }
    }
}