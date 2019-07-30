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
    public class carsController : ApiController
    {
        private CarFinance5917Entities db = new CarFinance5917Entities();

        // GET: api/cars
        public IQueryable<car> Getcar()
        {
            return db.car;
        }

        // GET: api/cars/5
        [ResponseType(typeof(car))]
        public IHttpActionResult Getcar(int id)
        {
            car car = db.car.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcar(int id, car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.carcode)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!carExists(id))
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

        // POST: api/cars
        [ResponseType(typeof(car))]
        public IHttpActionResult Postcar(car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.car.Add(car);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = car.carcode }, car);
        }

        // DELETE: api/cars/5
        [ResponseType(typeof(car))]
        public IHttpActionResult Deletecar(int id)
        {
            car car = db.car.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.car.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool carExists(int id)
        {
            return db.car.Count(e => e.carcode == id) > 0;
        }
    }
}