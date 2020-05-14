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
    public class RoutesController : ApiController
    {
        private ZealandModel db = new ZealandModel();

        // GET: api/Routes
        public IQueryable<Route> GetRoute()
        {
            return db.Route;
        }

        // GET: api/Routes/5
        [ResponseType(typeof(Route))]
        public IHttpActionResult GetRoute(int id)
        {
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return NotFound();
            }

            return Ok(route);
        }

        // PUT: api/Routes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoute(int id, Route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != route.id)
            {
                return BadRequest();
            }

            db.Entry(route).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
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

        // POST: api/Routes
        [ResponseType(typeof(Route))]
        public IHttpActionResult PostRoute(Route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Route.Add(route);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = route.id }, route);
        }

        // DELETE: api/Routes/5
        [ResponseType(typeof(Route))]
        public IHttpActionResult DeleteRoute(int id)
        {
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return NotFound();
            }

            db.Route.Remove(route);
            db.SaveChanges();

            return Ok(route);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RouteExists(int id)
        {
            return db.Route.Count(e => e.id == id) > 0;
        }
    }
}