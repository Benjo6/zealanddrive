using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Passenger
    {
        private int _id;
        private int _userId;
        private int _routeId;
        private string _status;

        
        public int id
        {
            get => _id;
            set => _id = value;
        }
        public int userId
        {
            get => _userId;
            set => _userId = value;
        }

        public int routeId
        {
            get => _routeId;
            set => _routeId = value;
        }

        public string status
        {
            get => _status;
            set => _status = value;
        }

        public Passenger()
        {
            
        }
        public Passenger(int id, int userId, int routeId, string status)
        {
            _id = id;
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
