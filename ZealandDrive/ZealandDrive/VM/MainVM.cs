using ClassLibrary;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ZealandDrive.Common;
using ZealandDrive.Lists;
using ZealandDrive.Model;
using ZealandDrive.Persistens;
using ZealandDrive.View;
using ZealandDrive.Persistens.Bil;

namespace ZealandDrive.VM
{
    class MainVM : INotifyPropertyChanged
    {
        #region Instance

        private Commands c;
        private Singleton x;
        private Listerne lists;

        private ObservableCollection<string> _adresseList;

        private IPersistens<Users> _persistence;
        private IPersistens<Car> _persistenceCar;
        private IPersistens<Route> _persistenceRoute;
        

        private Users _userToBeCreated;
        private ICommand _createOne;
        private ICommand _loadUser;
        private ICommand _saveUser;
        private ICommand _updateOneUser;
        private ICommand _deleteOneUser;
        private ICommand _clearCreateOneUser;
        private Users _selectedUser;
        private ObservableCollection<Users> _users;

        private Car _carToBeCreated;
        private ICommand _createOneCar;
        private ICommand _loadCar;
        private ICommand _saveCar;
        private ICommand _updateOneCar;
        private ICommand _deleteOneCar;
        private ICommand _clearCreateOneCar;
        private Car _selectedCar;
        private ObservableCollection<Car> _cars;


        private Route _ruteToBeCreated;
        private ICommand _createOneRute;
        private ICommand _loadRute;
        private ICommand _saveRute;
        private ICommand _updateOneRute;
        private ICommand _deleteOneRute;
        private ICommand _clearCreateOneRute;
        private Route _selectedRute;
        private ObservableCollection<Route> _ruter;



        private bool isChecked;
        private ICommand checkCommand;


        private RCO _nextCommand;
        #endregion

        #region Constructor
        public MainVM()
        {

            _adresseList = new ObservableCollection<string>();

            x = Singleton.Instance;
            lists = new Listerne();
            c = new Commands();
            _nextCommand = new RCO(Next);

            _persistence = PersitenceFactory.GetPersistency(PersistenceType.Database);
            _persistenceCar = new DBPersistenceCar();

            _loadUser = new RelayCommand(LoadUsers);
            _userToBeCreated = new Users();
            _users = new ObservableCollection<Users>();
            _createOne = new RelayCommand(Opret);
            _selectedUser = new Users();
            _updateOneUser = new RelayCommand(UpdateUser);
            _deleteOneUser = new RelayCommand(DeleteUser);
            _clearCreateOneUser = new RelayCommand(ClearCreateUser);

            _loadCar = new RelayCommand(LoadCars);
            _carToBeCreated = new Car();
            _cars = new ObservableCollection<Car>();
            _createOneCar = new RelayCommand(OpretCar);
            _selectedCar = new Car();
            _updateOneCar = new RelayCommand(UpdateCar);
            _deleteOneCar = new RelayCommand(DeleteCar);
            _clearCreateOneCar = new RelayCommand(ClearCreateCar);

            _loadCar = new RelayCommand(LoadRutes);
            _carToBeCreated = new Car();
            _cars = new ObservableCollection<Car>();
            _createOneCar = new RelayCommand(OpretRute);
            _selectedCar = new Car();
            _updateOneCar = new RelayCommand(UpdateRute);
            _deleteOneCar = new RelayCommand(DeleteRute);
            _clearCreateOneCar = new RelayCommand(ClearCreateRute);
        }

        #endregion

        #region Properties
        //public bool IsChecked
        //{
        //    get { return isChecked; }
        //    set
        //    {
        //        isChecked = value;
        //        OnPropertyChanged("IsChecked");
        //    }
        //}

        //public ICommand CheckCommand
        //{
        //    get
        //    {
        //        if (checkCommand == null)
        //            checkCommand = new RelayCommand(Checkprocess(object), null);
        //        return checkCommand;
        //    }
        //    set
        //    {
        //        checkCommand = value;
        //        OnPropertyChanged("CheckCommand");
        //    }
        //}

        public RelayCommand GoToOpretBruger => c.Opret;

        public ObservableCollection<string> H => lists.Timer;

        public ObservableCollection<string> M => lists.Minutter;

        public RelayCommand GoToLogin => c.Login;

        public RelayCommand GoToOpretRute => c.OpretRute;

        public RelayCommand GoToOverview => c.GoOverviewPage;

        public RelayCommand GoBack => c.Tilbage;

        public Singleton Instance => x;

        public RelayCommand Setting => c.SettingPage;
        
        public RCO NextCommand
        {
            get { return _nextCommand; }
        }


        public ObservableCollection<Users> Users => _users;

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

        public ICommand LoadUser => _loadUser;

        public ICommand Save => _saveUser;

        public ICommand UpdateOne => _updateOneUser;

        public ICommand DeleteOne => _deleteOneUser;

        public ICommand CreateOne => _createOne;

        public ICommand ClearCreateOneUser => _clearCreateOneUser;


        public ObservableCollection<Car> Cars => _cars;

        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                if (Equals(value, _selectedCar)) return;
                _selectedCar = value;
                OnPropertyChanged();
            }
        }

        public Car CarToBeCreated
        {
            get => _carToBeCreated;
            set
            {
                if (Equals(value, _carToBeCreated)) return;
                _carToBeCreated = value;
                OnPropertyChanged();
            }
        }


        public ICommand LoadCar => _loadCar;
        
        public ICommand SaveCar => _saveCar;

        public ICommand UpdateOneCar => _updateOneCar;

        public ICommand DeleteOneCar => _deleteOneCar;

        public ICommand CreateOneCar => _createOneCar;

        public ICommand ClearCreateOneCar => _clearCreateOneCar;

        public ObservableCollection<string> AdresseList => _adresseList;

        public ObservableCollection<Route> Ruter => _ruter;

        public Route SelectedRute
        {
            get => _selectedRute;
            set
            {
                if (Equals(value, _selectedRute)) return;
                _selectedRute = value;
                OnPropertyChanged();
            }
        }

        public Route RouteToBeCreated
        {
            get => _ruteToBeCreated;
            set
            {
                if (Equals(value, _ruteToBeCreated)) return;
                _ruteToBeCreated = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadRute => _loadRute;

        public ICommand SaveRute => _saveRute;

        public ICommand UpdateOneRute => _updateOneRute;

        public ICommand DeleteOneRute => _deleteOneRute;

        public ICommand CreateOneRute => _createOneRute;

        public ICommand ClearCreateOneRutes => _clearCreateOneCar;

        #endregion

        #region Method
        //public void Checkprocess(object sender)
        //{
        //    //this DOES react when the checkbox is checked or unchecked
        //}



        private void Next(object obj)
        {
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(SpecificRoutePage));
        }


        private async void Opret()
        {

                //todo give error message
                await _persistence.Opret(_userToBeCreated);

                //_users.Add(_userToBeCreated);
                Frame f = (Frame)Window.Current.Content;
                f.Navigate(typeof(LoginPage));
            
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

        private void UpdateUser()
        {
            if (_selectedUser != null)
            {
                //todo give error message
                _persistence.Update(_selectedUser);
            }
        }

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

        private async void OpretCar()
        {

            //todo give error message
            await _persistenceCar.Opret(_carToBeCreated);

            //_users.Add(_userToBeCreated);
            //Frame f = (Frame)Window.Current.Content;
            //f.Navigate(typeof(LoginPage));

        }
        private void UpdateCar()
        {
            if (_selectedCar != null)
            {
                //todo give error message
                _persistenceCar.Update(_selectedCar);
            }
        }

        private async void LoadCars()
        {
            _cars.Clear();
            var liste = await _persistenceCar.Load();
            foreach (Car c in liste)
            {
                _cars.Add(c);
            }
        }

        private void DeleteCar()
        {
            if (_selectedCar != null)
            {
                //todo give error message
                _persistenceCar.Delete(_selectedCar);
                _cars.Remove(_selectedCar);
            }
        }

        private void ClearCreateCar()
        {
            CarToBeCreated = new Car();
        }



        private async void OpretRute()
        {

            //todo give error message
            await _persistenceRoute.Opret(_ruteToBeCreated);

            //_users.Add(_userToBeCreated);
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(OverviewPage));

        }

        private async void LoadRutes()
        {
            _ruter.Clear();
            var liste = await _persistenceRoute.Load();
            foreach (Route r in liste)
            {
                _ruter.Add(r);
            }
        }

        private void UpdateRute()
        {
            if (_selectedUser != null)
            {
                //todo give error message
                _persistenceRoute.Update(_selectedRute);
            }
        }

        private void DeleteRute()
        {
            if (_selectedRute != null)
            {
                //todo give error message
                _persistenceRoute.Delete(_selectedRute);
                _ruter.Remove(_selectedRute);
            }
        }

        private void ClearCreateRute()
        {
            RouteToBeCreated = new Route();
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
