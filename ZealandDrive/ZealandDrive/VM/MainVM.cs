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
        private Singleton x;
        private ObservableCollection<Rute> _rutes;
        private RelayCommand _addRuteCommand;
        private Rute _nyRute;
        private CompositeCommand altiind;
        private Listerne lists;
        #endregion

        #region Constructor
        public MainVM()
        {
            x = Singleton.Instance;
            lists = new Listerne();
            c = new Commands();

            altiind = new CompositeCommand();
            altiind.Execute(AddRuter);
            altiind.Execute(c.GoOverviewPage);

            
            _addRuteCommand = new RelayCommand(AddRute);
  
        }

        #endregion

        #region Properties

        public ObservableCollection<string> H => lists.Timer;

        public ObservableCollection<string> M => lists.Minutter;


        public RelayCommand GoToLogin => c.Login;

        public Rute NyRute { get => x.NyRute; }

        public ObservableCollection<Rute> Ruter { get => x.Ruter;}
        public RelayCommand GoToOpretRute => c.OpretRute;

        public RelayCommand GoToOverview => c.GoOverviewPage;

        public RelayCommand GoBack => c.Tilbage;


        public RelayCommand AddRuter {get => _addRuteCommand;}

        public CompositeCommand OpretRuteKnap => altiind; 

       //public RelayCommand test => c.sRutePage;



        #endregion

        #region Method

        public void AddRute()
        {
            Ruter.Add(NyRute);
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
