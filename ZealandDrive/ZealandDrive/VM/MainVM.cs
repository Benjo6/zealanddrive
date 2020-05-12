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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using ZealandDrive.Common;
using ZealandDrive.Data;
using ZealandDrive.Lists;
using ZealandDrive.Model;
using ZealandDrive.View;

namespace ZealandDrive.VM
{
    class MainVM : INotifyPropertyChanged
    {
        #region Instance

        private Commands c;
        private Singleton x;
        private ObservableCollection<Rute> _rutes;
        private ICommand _opretUser;
        private RelayCommand _addRuter;
        private IPersistens _persistence;
        private User _userToBeCreated;
        private Rute _nyRute;
        private Listerne lists;
        private Bil bil;
        private ObservableCollection<Bil> _bils;
        private ObservableCollection<User> _users;

        private RCO _nextCommand;
        #endregion

        #region Constructor
        public MainVM()
        {
            x = Singleton.Instance;
            lists = new Listerne();
            c = new Commands();

            _addRuter = new RelayCommand(AddRute);

            


            _nextCommand = new RCO(Next);

            _userToBeCreated = new User();

            _users = new ObservableCollection<User>();

            _opretUser = new RelayCommand(OpretUser);

            //_persistence = PersitenceFactory.GetPersistency(PersistenceType.Database);
            //LoadMethod();
        }

        #endregion

        #region Properties
        public RelayCommand GoToOpretBruger => c.Opret;

        public ObservableCollection<string> H => lists.Timer;

        public ObservableCollection<string> M => lists.Minutter;

        public RelayCommand GoToLogin => c.Login;

        public Rute NyRute { get => x.NyRute; }

        public ObservableCollection<Rute> Ruter { get => x.Ruter; }

        public User UserToBeCreated
        {
            get => _userToBeCreated;
            set
            {
                if (Equals(value, _userToBeCreated)) return;
                _userToBeCreated = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<User> Users => _users;

        public RelayCommand GoToOpretRute => c.OpretRute;

        public RelayCommand GoToOverview => c.GoOverviewPage;

        public RelayCommand GoBack => c.Tilbage;

        public Singleton Instance => x;
        public Bil Bil
        {
            get => bil;
            set => bil = value; 
        }

        public ObservableCollection<Bil> BilDatabase => _bils;
        public RelayCommand AddRuter {get => _addRuter;}
        public RelayCommand Setting => c.SettingPage;
        
        public RCO NextCommand
        {
            get { return _nextCommand; }
        }



        #endregion

        #region Method
        public void AddRute()
        {
            Ruter.Add(NyRute);
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(OverviewPage));
        }

        private void Next(object obj)
        {
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(SpecificRoutePage));
        }

        private void OpretUser()
        {
            if (_userToBeCreated != null && _userToBeCreated.Id != -1)
            {
                //todo give error message
                _persistence.OpretUser(_userToBeCreated);
                _users.Add(_userToBeCreated);
            }
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
