using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ZealandDrive.Common
{
    class ralaycommand2 : ICommand
    {
        private Action <object,object> _metode;
        private Predicate<object> _predicate;
        private RelayCommand goToLogin;
        private object e;
        private object s;

        public event EventHandler CanExecuteChanged;

        public object E
        {
            get => e;
            set => e = value;
        }
        public object S
        {
            get => s;
            set => s = value;
        }

        public ralaycommand2(Action <object,object> metode, Predicate<object> pred)
        {
            _metode = metode;
            _predicate = pred;
            e = new object();
            s = new object();
        }

        public ralaycommand2(Action <object,object> metode)
        {
            _metode = metode;
            e = new object();
            s = new object();
        }



        public bool CanExecute(object parameter)
        {
            return _predicate == null ? true : _predicate(parameter);
        }

        public void Execute(object parameter)
        {
            _metode(e,s);
        }
    }
}
