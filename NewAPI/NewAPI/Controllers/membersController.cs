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
    public class membersController : ApiController
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: api/members
        public IQueryable<member> Getmember()
        {
            return db.member;
        }

        // GET: api/members/5
        [ResponseType(typeof(member))]
        public IHttpActionResult Getmember(string id)
        {
            member member = db.member.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/members/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmember(string id, member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != member.memidcard)
            {
                return BadRequest();
            }

            db.Entry(member).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!memberExists(id))
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

        // POST: api/members
        [ResponseType(typeof(member))]
        public IHttpActionResult Postmember(member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.member.Add(member);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (memberExists(member.memidcard))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = member.memidcard }, member);
        }

        // DELETE: api/members/5
        [ResponseType(typeof(member))]
        public IHttpActionResult Deletemember(string id)
        {
            member member = db.member.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            db.member.Remove(member);
            db.SaveChanges();

            return Ok(member);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool memberExists(string id)
        {
            return db.member.Count(e => e.memidcard == id) > 0;
        }
    }
}