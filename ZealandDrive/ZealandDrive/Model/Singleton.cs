using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model
{
    class Singleton
    {
        private static Singleton _x = new Singleton();
        private ObservableCollection<Rute> _rutes;
        private Rute _nyRute;




        private Singleton()
        {
            _nyRute = new Rute();
            _rutes = new ObservableCollection<Rute>();

        }

        public ObservableCollection<Rute> Ruter
        {
            get { return _rutes; }
            set { _rutes = value; }
        }

        public Rute NyRute
        {
            get { return _nyRute; }
            set { _nyRute = value; }
        }

        public static Singleton Instance
        {
            get { return _x; }
        }
        // Singleton slut

    }
}
