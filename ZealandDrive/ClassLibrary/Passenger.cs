using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Passenger
    {
        private int _userId;
        private int _routeId;
        private string _status;

        public int UserId
        {
            get => _userId;
            set => _userId = value;
        }

        public int RouteId
        {
            get => _routeId;
            set => _routeId = value;
        }

        public string Status
        {
            get => _status;
            set => _status = value;
        }

        public Passenger()
        {
            
        }
        public Passenger(int userId, int routeId, string status)
        {
            _userId = userId;
            _routeId = routeId;
            _status = status;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
