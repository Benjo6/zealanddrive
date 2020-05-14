﻿using ClassLibrary;
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
        private ObservableCollection<Route> _rutes;
        private Route _nyRute;
        private Route _selectedRute;




        private Singleton()
        {
            _nyRute = new Route();
            _rutes = new ObservableCollection<Route>();

        }
        public Route SelectedRute
        {
            get { return _selectedRute; }
            set
            {
                if (Equals(value, _selectedRute)) return;
                _selectedRute = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Route> Ruter
        {
            get { return _rutes; }
            set { _rutes = value; }
        }

        public Route NyRute
        {
            get { return _nyRute; }
            set { _nyRute = value; }
        }

        public static Singleton Instance
        {
            get { return _x; }
        }
        // Singleton slut
        public event PropertyChangedEventHandler PropertyChanged;
        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
