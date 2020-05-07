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
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using ZealandDrive.Lists;
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
        private Listerne lists;
        #endregion

        #region Constructor
        public MainVM()
        {
            lists = new Listerne();
            c = new Commands();
            _rutes = new ObservableCollection<Rute>();
            _rutes.Add(new Rute("Frederikssund", "Roskilde Zealand", "BMW","11","00", DateTimeOffset.Now,"Dummy"));
            _rutes.Add(new Rute("Frederikssund", "Roskilde Zealand", "BMW", "12", "00", DateTimeOffset.Now, "Dummy"));

            altiind = new CompositeCommand();
            altiind.Execute(AddRuter);
            altiind.Execute(c.GoOverviewPage);

            
            _addRuteCommand = new RelayCommand(AddRute);
            _nyRute = new Rute();
  
        }

        #endregion

        #region Properties

        public ObservableCollection<string> H => lists.Timer;

        public ObservableCollection<string> M => lists.Minutter;


        public RelayCommand GoToLogin => c.Login;

        public Rute NyRute { get => _nyRute; set => _nyRute = value;  }

        public ObservableCollection<Rute> Ruter { get => _rutes;}
        public RelayCommand GoToOpretRute => c.OpretRute;

        public RelayCommand GoToOverview => c.GoOverviewPage;

        public RelayCommand GoBack => c.Tilbage;

        public Singleton Shared => _shared;

        public RelayCommand AddRuter {get => _addRuteCommand;}

        public CompositeCommand OpretRuteKnap => altiind; 

       //public RelayCommand test => c.sRutePage;



        #endregion

        #region Method

        public void AddRute()
        {
            Ruter.Add(_nyRute);
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
