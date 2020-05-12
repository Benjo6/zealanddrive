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
using ZealandDrive.Model.Persistens;
using ZealandDrive.View;

namespace ZealandDrive.VM
{
    class MainVM : INotifyPropertyChanged
    {
        #region Instance

        private Commands c;
        private Singleton x;
        private ObservableCollection<Rute> _rutes;
        private RelayCommand _addRuter;
        private Rute _nyRute;
        private Listerne lists;
        private Bil bil;
        private ObservableCollection<Bil> _bils;

        private User _userToBeCreated;
        private ICommand _createOne;
        private IPersistens _persistence;
        private ICommand _loadUser;
        private ICommand _saveUser;
        private ICommand _updateOneUser;
        private ICommand _deleteOneUser;
        private ICommand _clearCreateOneUser;
        private User _selectedUser;
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
            _createOne = new RelayCommand(OpretUser);
            _selectedUser = new User();
            _loadUser = new RelayCommand(LoadMethod);
            _saveUser = new RelayCommand(SaveMethod);
            _updateOneUser = new RelayCommand(UpdateUser);
            _deleteOneUser = new RelayCommand(DeleteUser);
            _clearCreateOneUser = new RelayCommand(ClearCreate);
            _persistence = PersitenceFactory.GetPersistency(PersistenceType.Database);
            LoadMethod();

        }

        #endregion

        #region Properties
        public RelayCommand GoToOpretBruger => c.Opret;

        public ObservableCollection<string> H => lists.Timer;

        public ObservableCollection<string> M => lists.Minutter;

        public RelayCommand GoToLogin => c.Login;

        public Rute NyRute { get => x.NyRute; }

        public ObservableCollection<Rute> Ruter { get => x.Ruter; }

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


        public ObservableCollection<User> Users => _users;

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (Equals(value, _selectedUser)) return;
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

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

        public ICommand Load => _loadUser;

        public ICommand Save => _saveUser;

        public ICommand UpdateOne => _updateOneUser;

        public ICommand DeleteOne => _deleteOneUser;

        public ICommand CreateOne => _createOne;

        public ICommand ClearCreateOne => _clearCreateOneUser;



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

        private async void LoadMethod()
        {
            _users.Clear();
            var liste = await _persistence.LoadUsers();
            foreach (User u in liste)
            {
                _users.Add(u);
            }
        }

        private void SaveMethod()
        {
            _persistence.SaveUser(_users);
        }

        private void UpdateUser()
        {
            if (_selectedUser != null)
            {
                //todo give error message
                _persistence.UpdateUser(_selectedUser);
            }
        }

        private void DeleteUser()
        {
            if (_selectedUser != null)
            {
                //todo give error message
                _persistence.DeleteUser(_selectedUser);
                _users.Remove(_selectedUser);
            }
        }

        private void ClearCreate()
        {
            UserToBeCreated = new User();
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
