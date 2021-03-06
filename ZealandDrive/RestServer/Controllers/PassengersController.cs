﻿using System;
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
    public class PassengersController : ApiController
    {
        private ZealandModel db = new ZealandModel();

        // GET: api/Passengers
        public IQueryable<Passenger> GetPassengers()
        {
            return db.Passengers;
        }

        // GET: api/Passengers/5
        [ResponseType(typeof(Passenger))]
        public IHttpActionResult GetPassenger(int id)
        {
            Passenger passenger = db.Passengers.Find(id);
            if (passenger == null)
            {
                return NotFound();
            }

            return Ok(passenger);
        }

        // PUT: api/Passengers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPassenger(int id, Passenger passenger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != passenger.id)
            {
                return BadRequest();
            }

            db.Entry(passenger).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerExists(id))
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

        // POST: api/Passengers
        [ResponseType(typeof(Passenger))]
        public IHttpActionResult PostPassenger(Passenger passenger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Passengers.Add(passenger);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PassengerExists(passenger.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = passenger.id }, passenger);
        }

        // DELETE: api/Passengers/5
        [ResponseType(typeof(Passenger))]
        public IHttpActionResult DeletePassenger(int id)
        {
            Passenger passenger = db.Passengers.Find(id);
            if (passenger == null)
            {
                return NotFound();
            }

            db.Passengers.Remove(passenger);
            db.SaveChanges();

            return Ok(passenger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PassengerExists(int id)
        {
            return db.Passengers.Count(e => e.id == id) > 0;
        }
    }
}