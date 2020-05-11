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
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<Users> Get()
        {
            ManageUsers mgr = new ManageUsers();
            return mgr.HentAlle();
        }

        // GET: api/User/5
        public Users Get(int id)
        {
            ManageUsers mgr = new ManageUsers();
            return mgr.HentEn(id);
        }

        // POST: api/User
        public bool Post([FromBody]Users value)
        {
            ManageUsers mgr = new ManageUsers();
            return mgr.Opret(value);
        }

        // PUT: api/User/5
        public bool Put(int id, [FromBody]Users value)
        {
            ManageUsers mgr = new ManageUsers();
            return mgr.Update(value);
        }

        // DELETE: api/User/5
        public Users Delete(int id)
        {
            ManageUsers mgr = new ManageUsers();
            return mgr.Slet(id);
        }
    }
}
