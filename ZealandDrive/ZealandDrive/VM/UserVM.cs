using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ZealandDrive.Common;
using ZealandDrive.Model;
using ZealandDrive.Persistens;
using ZealandDrive.View;

namespace ZealandDrive.VM
{
    class UserVM : INotifyPropertyChanged
    {
        #region Instance
        // SingleTon
        private readonly Singleton x;
        // page
        private readonly PageCommand p;
        // users
        private readonly IPersistens<Users> _persistence;
        private readonly ObservableCollection<Users> _users;
        private Users _userToBeCreated;
        private Users _selectedUser;
        private Users _userTobeUpdated;
        private string _userNow;
        private string _passNow;
        private string _nameNow;
        private string _lastNameNow;
        private string _emailNow;
       
        //relay
        //private RelayCommand _saveUser;
        private readonly RelayCommand _updateOneUser;
        private readonly RelayCommand _deleteOneUser;
        private readonly RelayCommand _clearCreateOneUser;
        private readonly RelayCommand _checkBruger;
        private readonly RelayCommand _loadUser;
        private readonly RelayCommand _createOne;
        private readonly RelayCommand _createOne2;
        private  RelayCommand _userLogin;
        private readonly RelayCommand _loadCurrentUser;

        #endregion

        #region Constructor

        public UserVM()
        {
            //Singleton
            x = Singleton.Instance;
            //Page
            p = new PageCommand();
            //User
            _loadCurrentUser = new RelayCommand(LoadCurrentUsers);
            _userLogin = new RelayCommand(CheckBruger);
            _createOne2 = new RelayCommand(AddUser1);
            _loadUser = new RelayCommand(LoadUsers);
            _userToBeCreated = new Users();
            _createOne = new RelayCommand(OpretUser);
            _selectedUser = new Users();
            _updateOneUser = new RelayCommand(UpdateUser);
            _deleteOneUser = new RelayCommand(DeleteUser);
            _clearCreateOneUser = new RelayCommand(ClearCreateUser);
            _persistence = PersitenceFactory.GetPersistency(PersistenceType.Database);
            _users = new ObservableCollection<Users>();
            //_saveUser = new RelayCommand(SaveMethod);
        }

        #endregion

        #region Properties

        // page
        public RelayCommand UserTest => p.UserTest;
        public RelayCommand GoToOverview => p.GoOverviewPage;
        public RelayCommand GoToOpretBruger => p.Opret;
        public RelayCommand GoToLogin => p.Login;
        public RelayCommand GoToOverviewEN => p.GoOverviewPageEN;
        public RelayCommand GoToOpretBrugerEN => p.OpretEN;
        public RelayCommand GoToLoginEN => p.LoginEN;
        public RelayCommand GoBack => p.Tilbage;
        public RelayCommand GoFo => p.FOPage;
        public RelayCommand Setting => p.SettingPage;
        public RelayCommand GoOverview => p.GoOverviewPage;


        // user
        public ObservableCollection<Users> Users => _users;
        //public RelayCommand SaveUser => _saveUser;
        public Users SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (Equals(value, _selectedUser)) return;
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        public Users UserToBeCreated
        {
            get => _userToBeCreated;
            set
            {
                if (Equals(value, _userToBeCreated)) return;
                _userToBeCreated = value;
                OnPropertyChanged();
            }
        }

        public Users UserToBeUpdated
        {
            get => _userToBeCreated;
            set
            {
                if (Equals(value, _userTobeUpdated)) return;
                {
                    _userTobeUpdated = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand LoadUser => _loadUser;
        public RelayCommand LoadCurrentUser => _loadCurrentUser;
        public RelayCommand AddUser => _createOne2;

        public RelayCommand UserLogin
        {
            get { return _userLogin; }
            set { _userLogin = value; }
        }
        public UserVM(string userNow)
        {
            _userNow = userNow;
            x.UserCurrent = new Users();
        }

        public string PassNow
        {
            get => _passNow;
            set
            {
                _passNow = value;
                OnPropertyChanged();
            }
        }
        public Users UserCurrent => x.UserCurrent;
        public string UserNow
        {
            get => _userNow;
            set
            {
                _userNow = value;
                OnPropertyChanged();
            }
        }

        public string NameNow
        {
            get => _nameNow;
            set
            {
                _nameNow = value;
                OnPropertyChanged();
            }
        }
        public string LastNameNow
        {
            get => _lastNameNow;
            set
            {
                _lastNameNow = value;
                OnPropertyChanged();
            }
        }
        public string EmailNow
        {
            get => _emailNow;
            set
            {
                _emailNow = value;
                OnPropertyChanged();
            }
        }
        //public RelayCommand Save => _saveUser;

        public RelayCommand UpdateOne => _updateOneUser;

        public RelayCommand DeleteOne => _deleteOneUser;

        public RelayCommand CreateOne => _createOne;

        public RelayCommand ClearCreateOneUser => _clearCreateOneUser;
        
        #endregion

        #region Method
        private void DeleteUser()
        {
            if (_selectedUser != null)
            {
                //todo give error message
                _persistence.Delete(_selectedUser);
                _users.Remove(_selectedUser);
            }
        }
        private void ClearCreateUser()
        {
            UserToBeCreated = new Users();
        }
        private void UpdateUser()
        {
            if (_selectedUser != null)
            {
                //todo give error message
                _persistence.Update(_selectedUser);
            }
        }

        private async void LoadCurrentUsers()
        {
            _users.Clear();
            var liste = await _persistence.Load();
            foreach (Users u in liste)
            {
                if (UserCurrent.id == u.id )
                {
                    _users.Add(u);
                }
                
            }
        }
        private async void LoadUsers()
        {
            _users.Clear();
            var liste = await _persistence.Load();
            foreach (Users u in liste)
            {
                _users.Add(u);
            }
        }

        private async void OpretUser()
        {
            //todo give error message
            await _persistence.Opret(_userToBeCreated);

            //_users.Add(_userToBeCreated);
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(LoginPage));
        }
        private async void AddUser1()
        {

            //todo give error message
            await _persistence.Opret(_userToBeCreated);

            //_users.Add(_userToBeCreated);
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(LoginPage));

        }


        //private void SaveMethod()
        //{
        //    _persistence.SaveUser(_users);
        //}



        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool CheckList(string s1, string s2)
        {
            if (s1.Equals(s2)) { return true; }
            return false;
        }
        public async void CheckBruger()
        {

            //await _persistence.Load();
            foreach (Users i in await _persistence.Load())
            {
                if (CheckList(i.email, _userNow) && (CheckList(i.password, _passNow)))
                {
                    x.UserCurrent = i;
                    UserNow = "";
                    PassNow = "";
                    Frame f = (Frame)Window.Current.Content;
                    f.Navigate(typeof(OverviewPage));
                    //UserCurrent = obj;
                    //UserNow = "";
                    //PassNow = "";

                    //Frame login = (Frame)Window.Current.Content;
                    //login.Navigate(typeof(lplplp.View.Kort));
                    // LoginSuccess = "lplplp.Kort";
                    //LoginPopUp();
                }
                else
                {
                }
            }
        }
        #endregion
    }
}
