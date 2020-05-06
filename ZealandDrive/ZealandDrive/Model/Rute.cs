using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model
{
    class Rute
    {
        private static int Counter = 0;

        private int _id;

        private string _startSted;

        private string _slutSted;

        private string _bil;

        private TimeSpan _tid;

        private DateTime _date;

        private string _besked;

        public Rute() : this("", "", "", TimeSpan.MinValue ,DateTime.MinValue, "")
        {
        }

        public Rute(string startSted, string slutSted, string bil, TimeSpan Tid, DateTime Date, string besked)
        {
            _id = Counter++;
            _startSted = startSted;
            _slutSted = slutSted;
            _bil = bil;
            _tid = Tid;
            _date = Date;
            _besked = besked;
        }

        public static int Counter1
        {
            get => Counter;
            set => Counter = value;
        }
        public int Id => _id;

        public string Start
        {
            get => _startSted;
            set => _startSted = value;
        }
        public string Slut
        {
            get => _slutSted;
            set => _slutSted = value;
        }
        public string Bil
        {
            get => _bil;
            set => _bil = value;
        }

        public TimeSpan Tid
        {
            get => _tid;
            set => _tid = value;
        }
        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }
        public string Besked
        {
            get => _besked;
            set => _besked = value;
        }
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Start)}: {Start}, {nameof(Slut)}: {Slut}, {nameof(Bil)}: {Bil}, {nameof(Tid)}: {Tid}, {nameof(Date)}: {Date}, {nameof(Besked)}: {Besked} ";
        }

    }
}
