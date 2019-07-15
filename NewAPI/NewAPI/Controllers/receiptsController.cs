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
    public class receiptsController : ApiController
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: api/receipts
        public IQueryable<receipt> Getreceipt()
        {
            return db.receipt;
        }

        // GET: api/receipts/5
        [ResponseType(typeof(receipt))]
        public IHttpActionResult Getreceipt(string id)
        {
            receipt receipt = db.receipt.Find(id);
            if (receipt == null)
            {
                return NotFound();
            }

            return Ok(receipt);
        }

        // PUT: api/receipts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putreceipt(string id, receipt receipt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != receipt.recode)
            {
                return BadRequest();
            }

            db.Entry(receipt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!receiptExists(id))
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

        // POST: api/receipts
        [ResponseType(typeof(receipt))]
        public IHttpActionResult Postreceipt(receipt receipt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.receipt.Add(receipt);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (receiptExists(receipt.recode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = receipt.recode }, receipt);
        }

        // DELETE: api/receipts/5
        [ResponseType(typeof(receipt))]
        public IHttpActionResult Deletereceipt(string id)
        {
            receipt receipt = db.receipt.Find(id);
            if (receipt == null)
            {
                return NotFound();
            }

            db.receipt.Remove(receipt);
            db.SaveChanges();

            return Ok(receipt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool receiptExists(string id)
        {
            return db.receipt.Count(e => e.recode == id) > 0;
        }
    }
}