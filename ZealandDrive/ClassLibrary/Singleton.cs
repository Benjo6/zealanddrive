using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class Singleton
    {
        private int _UserCurrent;
        private static Singleton _x = new Singleton();
        private Singleton()
        {
            
            _UserCurrent = new int();

        }
        public static Singleton Instance
        {
            get { return _x; }
        }
        public int UserCurrent
        {
            get => _UserCurrent;
            set => _UserCurrent = value;
        }
    }
}
