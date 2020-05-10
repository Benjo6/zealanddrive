using Hangfire.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZealandDrive.Model;

namespace ZealandDrive.Common
{
    class SharedKnowledge : INotifyPropertyChanged
    {
        private Rute _selectedRute;
        private static SharedKnowledge _instance = new SharedKnowledge();
        
        private SharedKnowledge()
        {
            Rute a = new Rute();

        }
        
        public static SharedKnowledge Instance
        {
            get { return _instance; }
        }
        public Rute SelectedRute
        {
            get { return _selectedRute; }
            set
            {
                if (Equals(value, _selectedRute)) return;
                _selectedRute = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
