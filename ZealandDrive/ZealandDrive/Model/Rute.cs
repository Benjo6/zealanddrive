using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model
{
    class Rute
    {
        #region Instance
        private static int Counter = 0;

        private int _id;

        private string _startSted;

        private string _slutSted;

        private string _bil;

        private string _hour;

        private string _minute;


        private DateTimeOffset _date;

        private string _besked;


        #endregion

        #region Konstruktør
        public Rute() : this("", "", "", "", "" ,DateTime.Now, "")
        {
        }

        public Rute(string startSted, string slutSted, string bil, string hour, string minute, DateTimeOffset Date, string besked)
        {
            _id = Counter++;
            _startSted = startSted;
            _slutSted = slutSted;
            _bil = bil;
            _hour = hour;
            _minute = minute;
            _date = Date;
            _besked = besked;
          
        }

        #endregion

        #region Properties
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
        public DateTimeOffset Date
        {
            get => _date;
            set
            {
                _date = value;
            }
            
            
        }
        public string Besked
        {
            get => _besked;
            set => _besked = value;
        }
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Start)}: {Start}, {nameof(Slut)}: {Slut}, {nameof(Bil)}: {Bil}, {nameof(Hour)}: {Hour},{nameof(Minute)}: {Minute}, {nameof(Date)}: {Date}, {nameof(Besked)}: {Besked} ";
        }

        #endregion

    }
}
