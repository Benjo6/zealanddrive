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
    public class CarController : ApiController
    {
        // GET: api/Car

        ManageCar mgr = new ManageCar();
        public IEnumerable<Car> Get()
        {
            ManageCar mgr = new ManageCar();
            return mgr.HentAlle();
        }

        // GET: api/Car/5
        public Car Get(int id)
        {
            ManageCar mgr = new ManageCar();
            return mgr.HentEn(id);
        }

        // POST: api/Car
        public bool Post([FromBody]Car value)
        {
            ManageCar mgr = new ManageCar();
            return mgr.Opret(value);
        }

        // PUT: api/Car/5
        public bool Put(int id, [FromBody]Car value)
        {
            ManageCar mgr = new ManageCar();
            return mgr.Update(value);
        }

        // DELETE: api/Car/5
        public Car Delete(int id)
        {
            ManageCar mgr = new ManageCar();
            return mgr.Slet(id);
        }
    }
}
