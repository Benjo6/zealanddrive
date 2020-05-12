using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZealandDrive.Data;

namespace ZealandDrive.Model
{
    class Rute
    {
        #region Instance
        private static int Counter = 0;

        private int _id;

        private Tur _startSted;

        private Tur _slutSted;

        private Bil _bil;

        private string _hour;

        private string _minute;


        private DateTimeOffset _date;

        private string _besked;


        #endregion

        #region Konstruktør
        public Rute() : this(null, null, null, "", "" ,DateTime.Now, "")
        {
        }

        public Rute(Tur startSted, Tur slutSted, Bil bil, string hour, string minute, DateTimeOffset date, string besked)
        {
            _id = Counter++;
            _startSted = startSted;
            _slutSted = slutSted;
            _bil = bil;
            _hour = hour;
            _minute = minute;
            _date = date;
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

        public Tur Start
        {
            get => _startSted;
            set => _startSted = value;
        }
        public Tur Slut
        {
            get => _slutSted;
            set => _slutSted = value;
        }
        public Bil Bil
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
        public DateTimeOffset Dates
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
