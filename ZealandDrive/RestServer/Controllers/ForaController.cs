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
    public class ForaController : ApiController
    {
        private ZealandModel db = new ZealandModel();

        // GET: api/Fora
        public IQueryable<Forum> GetFora()
        {
            return db.Fora;
        }

        // GET: api/Fora/5
        [ResponseType(typeof(Forum))]
        public IHttpActionResult GetForum(int id)
        {
            Forum forum = db.Fora.Find(id);
            if (forum == null)
            {
                return NotFound();
            }

            return Ok(forum);
        }

        // PUT: api/Fora/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutForum(int id, Forum forum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != forum.id)
            {
                return BadRequest();
            }

            db.Entry(forum).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumExists(id))
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

        // POST: api/Fora
        [ResponseType(typeof(Forum))]
        public IHttpActionResult PostForum(Forum forum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fora.Add(forum);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = forum.id }, forum);
        }

        // DELETE: api/Fora/5
        [ResponseType(typeof(Forum))]
        public IHttpActionResult DeleteForum(int id)
        {
            Forum forum = db.Fora.Find(id);
            if (forum == null)
            {
                return NotFound();
            }

            db.Fora.Remove(forum);
            db.SaveChanges();

            return Ok(forum);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ForumExists(int id)
        {
            return db.Fora.Count(e => e.id == id) > 0;
        }
    }
}