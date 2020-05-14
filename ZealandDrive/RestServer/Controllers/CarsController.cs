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
using RestServer.Model;

namespace RestServer.Controllers
{
    public class CarsController : ApiController
    {
        private ZealandModel db = new ZealandModel();

        // GET: api/Cars
        public IQueryable<Car> GetCar()
        {
            return db.Car;
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCar(int id)
        {
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCar(int id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.id)
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
                if (!CarExists(id))
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

        // POST: api/Cars
        [ResponseType(typeof(Car))]
        public IHttpActionResult PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Car.Add(car);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = car.id }, car);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult DeleteCar(int id)
        {
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.Car.Remove(car);
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

        private bool CarExists(int id)
        {
            return db.Car.Count(e => e.id == id) > 0;
        }
    }
}