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
    public class typesController : ApiController
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: api/types
        public IQueryable<type> Gettype()
        {
            return db.type;
        }

        // GET: api/types/5
        [ResponseType(typeof(type))]
        public IHttpActionResult Gettype(int id)
        {
            type type = db.type.Find(id);
            if (type == null)
            {
                return NotFound();
            }

            return Ok(type);
        }

        // PUT: api/types/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttype(int id, type type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != type.typecode)
            {
                return BadRequest();
            }

            db.Entry(type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!typeExists(id))
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

        // POST: api/types
        [ResponseType(typeof(type))]
        public IHttpActionResult Posttype(type type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.type.Add(type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (typeExists(type.typecode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = type.typecode }, type);
        }

        // DELETE: api/types/5
        [ResponseType(typeof(type))]
        public IHttpActionResult Deletetype(int id)
        {
            type type = db.type.Find(id);
            if (type == null)
            {
                return NotFound();
            }

            db.type.Remove(type);
            db.SaveChanges();

            return Ok(type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool typeExists(int id)
        {
            return db.type.Count(e => e.typecode == id) > 0;
        }
    }
}