using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model
{
    class Singleton
    {
        private static Singleton _instance = new Singleton();

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get { return _instance; }
        }
        // Singleton slut

    }
}
