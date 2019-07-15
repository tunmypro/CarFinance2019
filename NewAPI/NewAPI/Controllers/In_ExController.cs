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
    public class In_ExController : ApiController
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: api/In_Ex
        public IQueryable<In_Ex> GetIn_Ex()
        {
            return db.In_Ex;
        }

        // GET: api/In_Ex/5
        [ResponseType(typeof(In_Ex))]
        public IHttpActionResult GetIn_Ex(int id)
        {
            In_Ex in_Ex = db.In_Ex.Find(id);
            if (in_Ex == null)
            {
                return NotFound();
            }

            return Ok(in_Ex);
        }

        // PUT: api/In_Ex/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIn_Ex(int id, In_Ex in_Ex)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != in_Ex.no)
            {
                return BadRequest();
            }

            db.Entry(in_Ex).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!In_ExExists(id))
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

        // POST: api/In_Ex
        [ResponseType(typeof(In_Ex))]
        public IHttpActionResult PostIn_Ex(In_Ex in_Ex)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.In_Ex.Add(in_Ex);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = in_Ex.no }, in_Ex);
        }

        // DELETE: api/In_Ex/5
        [ResponseType(typeof(In_Ex))]
        public IHttpActionResult DeleteIn_Ex(int id)
        {
            In_Ex in_Ex = db.In_Ex.Find(id);
            if (in_Ex == null)
            {
                return NotFound();
            }

            db.In_Ex.Remove(in_Ex);
            db.SaveChanges();

            return Ok(in_Ex);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool In_ExExists(int id)
        {
            return db.In_Ex.Count(e => e.no == id) > 0;
        }
    }
}