using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary;

namespace RestServer.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<Users> Get()
        {
            ManageUser mgr = new ManageUser();
            return mgr.HentAlle();
        }

        // GET: api/User/5
        public Users Get(int id)
        {
            ManageUser mgr = new ManageUser();
            return mgr.HentEn();
        }

        // POST: api/User
        public bool Post([FromBody]Users value)
        {
            ManageUser mgr = new ManageUser();
            return mgr.Opret(value);
        }

        // PUT: api/User/5
        public bool Put(int id, [FromBody]Users value)
        {
            ManageUser mgr = new ManageUser();
            return mgr.Update(value);
        }

        // DELETE: api/User/5
        public Users Delete(int id)
        {
            ManageUser mgr = new ManageUser();
            return mgr.Slet(id);
        }
    }
}
