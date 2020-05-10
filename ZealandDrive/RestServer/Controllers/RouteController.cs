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
    public class RouteController : ApiController
    {
        // GET: api/Route
        public IEnumerable<Route> Get()
        {
            ManageRoute mgr = new ManageRoute();
            return mgr.HentAlle();
        }

        // GET: api/Route/5
        public Route Get(int id)
        {
            ManageRoute mgr = new ManageRoute();
            return mgr.HentEn(id);
        }

        // POST: api/Route
        public bool Post([FromBody]Route value)
        {
            ManageRoute mgr = new ManageRoute();
            return mgr.Opret(value);
        }

        // PUT: api/Route/5
        public bool Put(int id, [FromBody]Route value)
        {
            ManageRoute mgr = new ManageRoute();
            return mgr.Update(value);
        }

        // DELETE: api/Route/5
        public Route Delete(int id)
        {
            ManageRoute mgr = new ManageRoute();
            return mgr.Slet(id);
        }
    }
}
