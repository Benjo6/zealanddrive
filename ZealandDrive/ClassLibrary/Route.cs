using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Route
    {
        private int _id;
        private string _routeStart;
        private string _routeEnd;
        private DateTime _startTime;
        private int _carId;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string RouteStart
        {
            get => _routeStart;
            set => _routeStart = value;
        }

        public string RouteEnd
        {
            get => _routeEnd;
            set => _routeEnd = value;
        }

        public DateTime StartTime
        {
            get => _startTime;
            set => _startTime = value;
        }

        public int CarId
        {
            get => _carId;
            set => _carId = value;
        }

        public Route(int id, string routeStart, string routeEnd, DateTime startTime, int carId)
        {
            _id = id;
            _routeStart = routeStart;
            _routeEnd = routeEnd;
            _startTime = startTime;
            _carId = carId;
        }

        public Route()
        {
        
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
