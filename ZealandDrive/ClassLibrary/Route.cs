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
        private string _hour;
        private string _minute;
        private int _carId;
        private string _besked;


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
        public string Hour
        {
            get => _hour;
            set => _hour = value;
        }
        public string Minute
        {
            get => _minute;
            set => _minute = value;
        }
        public string Besked
        {
            get => _besked;
            set => _besked = value;
        }

        public Route(int id, string routeStart, string routeEnd, DateTime startTime, string hours, string minute, int carId, string besked)
        {
            _id = id;
            _routeStart = routeStart;
            _routeEnd = routeEnd;
            _startTime = startTime;
            _carId = carId;
            _besked = besked;
            _hour = hours;
            _minute = minute;
        }

        public Route() : this (0, "","",DateTime.Now,"","",0,"")
        {
        
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
