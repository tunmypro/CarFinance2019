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
    public class gensController : ApiController
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: api/gens
        public IQueryable<gen> Getgen()
        {
            return db.gen;
        }

        // GET: api/gens/5
        [ResponseType(typeof(gen))]
        public IHttpActionResult Getgen(int id)
        {
            gen gen = db.gen.Find(id);
            if (gen == null)
            {
                return NotFound();
            }

            return Ok(gen);
        }

        // PUT: api/gens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgen(int id, gen gen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gen.gencode)
            {
                return BadRequest();
            }

            db.Entry(gen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!genExists(id))
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

        // POST: api/gens
        [ResponseType(typeof(gen))]
        public IHttpActionResult Postgen(gen gen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.gen.Add(gen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gen.gencode }, gen);
        }

        // DELETE: api/gens/5
        [ResponseType(typeof(gen))]
        public IHttpActionResult Deletegen(int id)
        {
            gen gen = db.gen.Find(id);
            if (gen == null)
            {
                return NotFound();
            }

            db.gen.Remove(gen);
            db.SaveChanges();

            return Ok(gen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool genExists(int id)
        {
            return db.gen.Count(e => e.gencode == id) > 0;
        }
    }
}