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
        private ObservableCollection<Route> _rutes;
        private RelayCommand _addRuter;
        private Route _nyRute;
        private Listerne lists;
        private Car bil;
        private ObservableCollection<Car> _bils;
        private RelayCommand _addCar;


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

        private bool isChecked;
        private ICommand checkCommand;


        private RCO _nextCommand;
        #endregion

        #region Constructor
        public MainVM()
        {
            x = Singleton.Instance;
            lists = new Listerne();
            c = new Commands();

            // _addRuter = new RelayCommand(AddRute);

            _nextCommand = new RCO(Next);
            //IsChecked = true;
            //_addCar = new RelayCommand(AddCar);

            //_loadUser = new RelayCommand(LoadMethod);
            _persistence = PersitenceFactory.GetPersistency(PersistenceType.Database);
            _persistenceCar = new DBPersistenceCar();
            //_persistenceRoute = PersitenceFactory.GetPersistency(PersistenceType.Database);

            //LoadMethod();

            _userToBeCreated = new Users();
            _users = new ObservableCollection<Users>();
            _createOne = new RelayCommand(Opret);
            _selectedUser = new Users();
            _updateOneUser = new RelayCommand(UpdateUser);
            _deleteOneUser = new RelayCommand(DeleteUser);
            _clearCreateOneUser = new RelayCommand(ClearCreate);

            _carToBeCreated = new Car();
            _cars = new ObservableCollection<Car>();
            _createOneCar = new RelayCommand(OpretCar);
            _selectedCar = new Car();
            _updateOneCar = new RelayCommand(UpdateCar);
            _deleteOneCar = new RelayCommand(DeleteCar);
            _clearCreateOneCar = new RelayCommand(ClearCreateOneCar);
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

        public Route NyRute { get => x.NyRute; }

        public ObservableCollection<Route> Ruter { get => x.Ruter; }

        public RelayCommand GoToOpretRute => c.OpretRute;

        public RelayCommand GoToOverview => c.GoOverviewPage;

        public RelayCommand GoBack => c.Tilbage;

        public Singleton Instance => x;
        public Car NewCar
        {
            get => bil;
            set => bil = value; 
        }

        public ObservableCollection<Car> BilDatabase => _bils;
        public RelayCommand AddRuter {get => _addRuter;}
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

        public ICommand Load => _loadUser;

        public ICommand Save => _saveUser;

        public ICommand UpdateOne => _updateOneUser;

        public ICommand DeleteOne => _deleteOneUser;

        public ICommand CreateOne => _createOne;

        public ICommand ClearCreateOne => _clearCreateOneUser;


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

        public ICommand ClearCreateOneCars => _clearCreateOneCar;


        #endregion

        #region Method
        //public void Checkprocess(object sender)
        //{
        //    //this DOES react when the checkbox is checked or unchecked
        //}

        //public void AddCar()
        // {
        //     if (NewCar != null)
        //     {
        //         _persistence.Opret(NewCar);
        //         Frame f = (Frame)Window.Current.Content;
        //         f.Navigate(typeof(OverviewPage));
        //     }

        // }

        //public void AddRute()
        //{
        //    if (NyRute != null)
        //    {
        //        _persistence.Opret(NyRute);
        //        Frame f = (Frame)Window.Current.Content;
        //        f.Navigate(typeof(OverviewPage));
        //    }
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

        //private async void LoadMethod()
        //{
        //    _users.Clear();
        //    var liste = await _persistence.Load();
        //    foreach (User u in liste)
        //    {
        //        _users.Add(u);
        //    }
        //}


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

        private void ClearCreate()
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

        private void DeleteCar()
        {
            if (_selectedCar != null)
            {
                //todo give error message
                _persistenceCar.Delete(_selectedCar);
                _cars.Remove(_selectedCar);
            }
        }

        private void ClearCreateOneCar()
        {
            CarToBeCreated = new Car();
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
