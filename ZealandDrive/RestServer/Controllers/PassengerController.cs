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
    public class PassengerController : ApiController
    {
        // GET: api/Passenger
        public IEnumerable<Passenger> Get()
        {
            ManagePassenger mgr = new ManagePassenger();
            return mgr.HentAlle();
        }

        // GET: api/Passenger/5
        public Passenger Get(int id)
        {
            ManagePassenger mgr = new ManagePassenger();
            return mgr.HentEn(id);
        }

        // POST: api/Passenger
        public bool Post([FromBody]Passenger value)
        {
            ManagePassenger mgr = new ManagePassenger();
            return mgr.Opret(value);
        }

        // PUT: api/Passenger/5
        public bool Put(int id, [FromBody]Passenger value)
        {
            ManagePassenger mgr = new ManagePassenger();
            return mgr.Update(value);
        }

        // DELETE: api/Passenger/5
        public Passenger Delete(int id)
        {
            ManagePassenger mgr = new ManagePassenger();
            return mgr.Slet(id);
        }
    }
}
