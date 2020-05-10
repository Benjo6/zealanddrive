using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary;
using RestServer.DBUtil;

namespace RestServer.Controllers
{
    public class CommentsController : ApiController
    {
        // GET: api/Comments
        public IEnumerable<Comments> Get()
        {
            ManageComments mgr = new ManageComments();
            return mgr.HentAlle();
        }

        // GET: api/Comments/5
        public Comments Get(int id)
        {
            ManageComments mgr = new ManageComments();
            return mgr.HentEn(id);
        }

        // POST: api/Comments
        public bool Post([FromBody]Comments value)
        {
            ManageComments mgr = new ManageComments();
            return mgr.Opret(value);
        }

        // PUT: api/Comments/5
        public bool Put(int id, [FromBody]Comments value)
        {
            ManageComments mgr = new ManageComments();
            return mgr.Update(value);
        }

        // DELETE: api/Comments/5
        public Comments Delete(int id)
        {
            ManageComments mgr = new ManageComments();
            return mgr.Slet(id);
        }
    }
}
