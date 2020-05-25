using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class Route
    {
        private int _id;
        private string _routeStart;
        private string _routeEnd;
        private string _startTime;
        private DateTime _date;
        private string _hour;
        private string _minute;
        private int _carId;
        private string _besked;

        //private string _xstr = $"{hour}:{minutte}";

        public int id
        {
            get => _id;
            set => _id = value;
        }

        public string routeStart
        {
            get => _routeStart;
            set => _routeStart = value;
        }

        public string routeEnd
        {
            get => _routeEnd;
            set => _routeEnd = value;
        }

        public DateTime date { get; set; }

        public string startTime
        {
            get => _startTime;
            set => _startTime = value;
        }

        public int carId
        {
            get => _carId;
            set => _carId = value;
        }
        public string hour
        {
            get => _hour;
            set => _hour = value;
        }
        public string minute
        {
            get => _minute;
            set => _minute = value;
        }
        public string besked
        {
            get => _besked;
            set => _besked = value;
        }

        public Route(int id, string routeStart, string routeEnd, string startTime, DateTime date, string hours, string minute, int carId, string besked)
        {
            _id = id;
            _routeStart = routeStart;
            _routeEnd = routeEnd;
            _startTime = startTime;
            _date = date;
            _carId = carId;
            _besked = besked;
            _hour = hours;
            _minute = minute;
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
