using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ZealandDrive.Common
{
    class RelayCommand : ICommand
    {
        private Action _metode;
        private Predicate<object> _predicate;
        private RelayCommand goToLogin;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action metode, Predicate<object> pred)
        {
            _metode = metode;
            _predicate = pred;
        }

        public RelayCommand(Action metode)
        {
            _metode = metode;
        }

      

        public bool CanExecute(object parameter)
        {
            return _predicate == null ? true : _predicate(parameter);
        }

        public void Execute(object parameter)
        {
            _metode();
        }
    }
}
