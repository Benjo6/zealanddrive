using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZealandDrive.Model;

namespace ZealandDrive.VM
{
    class MainVM
    {
        #region Instance
        
        private Commands c;
        private Singleton _shared;
        private ObservableCollection<Rute> _rutes;
        private RelayCommand _addRuteCommand;
        private Rute _nyRute;
        private CompositeCommand altiind;
        private TimeSpanConverter _timeSpan;
        #endregion

        #region Constructor
        public MainVM()
        {
            c = new Commands();
            _nyRute = new Rute("", "", "", TimeSpan.Zero ,DateTime.Now, "");
            _rutes = new ObservableCollection<Rute>();
            _rutes.Add(new Rute("Frederikssund", "Roskilde Zealand", "BMW",TimeSpan.Zero, DateTime.Now, "Dummy"));
            altiind = new CompositeCommand();
            altiind.Execute(AddRuter);
            altiind.Execute(c.GoOverviewPage);
            _timeSpan = new TimeSpanConverter();

            _addRuteCommand = new RelayCommand(AddRute);
        }

        #endregion

        #region Properties


        public RelayCommand GoToLogin => c.Login;

        public Rute NyRute { get => _nyRute; set => _nyRute = value;  }

        public ObservableCollection<Rute> Ruter { get => _rutes; set => _rutes = value; }
        public RelayCommand GoToOpretRute => c.OpretRute;

        public RelayCommand GoToOverview => c.GoOverviewPage;

        public RelayCommand GoBack => c.Tilbage;

        public Singleton Shared => _shared;

        public RelayCommand AddRuter {get => _addRuteCommand; private set => _addRuteCommand = value;}

        public CompositeCommand OpretRuteKnap => altiind;





        #endregion

        #region Method

        public void AddRute()
        {
            Ruter.Add(NyRute);
            NyRute = new Rute("", "", "", TimeSpan.MinValue ,DateTime.MinValue, "");
        }
        
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
