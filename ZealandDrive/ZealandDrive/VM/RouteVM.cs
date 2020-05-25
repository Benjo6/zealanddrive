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
using Google.Protobuf.WellKnownTypes;
using ZealandDrive.Common;
using ZealandDrive.Model;
using ZealandDrive.Persistens;
using ZealandDrive.Persistens.Rute;
using ZealandDrive.View;
using ZealandDrive.Persistens.Bil;
using ZealandDrive.Lists;

namespace ZealandDrive.VM
{
    class RouteVM : INotifyPropertyChanged
    {
        #region Instance
        //lister
        private Listerne lists;
        private static string _hour;
        private static string _minute;
        private static DatePicker _datoValgt;
        private string _date;


        //Singleton
        private Singleton x;

        // Page
        private PageCommand p;
        private RCO _nextCommand;

        // Routes
        private IPersistens<Route> _persistenceRoute;
        private RelayCommand _createOneRute;
        private Route _selectedRute;
        private ralaycommand2 _loadRute;
        private Route _ruteToBeCreated;
        private RelayCommand _saveRute;
        private RelayCommand _updateOneRute;
        private RelayCommand _deleteOneRute;
        private RelayCommand _clearCreateOneRute;
        private ObservableCollection<Route> _ruter;
        private RelayCommand _handleR;
        private RelayCommand _loadRoute;

        // passenger
        private IPersistens<Passenger> _persistencePassenger;
        private RelayCommand _createOnePassenger;
        private Passenger _selectedPassenger;
        private RelayCommand _loadPassenger;
        private Passenger _passengerToBeCreated;
        private RelayCommand _savePassenger;
        private RelayCommand _updateOnePassengerDec;
        private RelayCommand _updateOnePassengerAcc;
        private RelayCommand _deleteOnePassenger;
        private RelayCommand _clearCreateOnePassenger;
        private ObservableCollection<Passenger> _passengers;
        private RelayCommand _loadCurrentPassenger;

        // cars
        private IPersistens<Car> _persistenceCar;
        private ObservableCollection<Car> _cars;
        private RelayCommand _loadCars;
        private Car _selectedCar;

        //user
        private UserVM _uvm;
        #endregion

        #region Constructor
        public RouteVM()
        {
            //lister
            lists = new Listerne();
            _hour = hour;
            _minute = minute;
            x = Singleton.Instance;
            _datoValgt = datoValgt;
            _date = date;
            //page
            p = new PageCommand();
            // route
            _loadRoute = new RelayCommand(LoadRoute);
            _loadRute = new ralaycommand2(LoadRutes);
            _ruteToBeCreated = new Route();
            _ruter = new ObservableCollection<Route>();
            _createOneRute = new RelayCommand(OpretRute1);
            _selectedRute = new Route();
            _updateOneRute = new RelayCommand(UpdateRute);
            _deleteOneRute = new RelayCommand(DeleteRute);
            _clearCreateOneRute = new RelayCommand(ClearCreateRute);
            _persistenceRoute = new DBPersistenceRute();
            _handleR = new RelayCommand(HandleSelectedItem);
            // passenger
            _loadPassenger = new RelayCommand(LoadPassengers);
            _passengerToBeCreated = new Passenger();
            _passengers = new ObservableCollection<Passenger>();
            _createOnePassenger = new RelayCommand(OpretPassenger);
            _selectedPassenger = new Passenger();
            _updateOnePassengerAcc = new RelayCommand(UpdatePassengerAccept);
            _updateOnePassengerDec = new RelayCommand(UpdatePassengerDecline);
            _deleteOnePassenger = new RelayCommand(DeletePassenger);
            _clearCreateOnePassenger = new RelayCommand(ClearCreatePassenger);
            _persistencePassenger = new DBPersistencePassenger();
            _loadCurrentPassenger = new RelayCommand(LoadCurrentPassenger);
            // car
            _selectedCar = new Car();
            _loadCars = new RelayCommand(LoadCars);
            _cars = new ObservableCollection<Car>();
            _persistenceCar = new DBPersistenceCar();
            //user
            _uvm = new UserVM();
        }
        #endregion
        #region Properties
        //lister
        public ObservableCollection<string> H => lists.Timer;
        public ObservableCollection<string> M => lists.Minutter;

        public string hour
        {
            get => _hour;
            set => _hour = value;
        }
        public string minute
        {
            get => _minute;
            set => _minute = value;

        }
        public DatePicker datoValgt
        {
            get => _datoValgt;
            set => _datoValgt = value;
        }
        public string date
        {
            get => _date;
            set => _date = $"{_ruteToBeCreated.datoValgt}";
        }

        // page
        public Singleton Instance => x;
        public RelayCommand GoToOverview => p.GoOverviewPage;
        public RelayCommand GoFo => p.FOPage;
        public RelayCommand Setting => p.SettingPage;
        public RelayCommand GoGemBiler => p.GemBiler;

        public RelayCommand GoToOverviewEN => p.GoOverviewPageEN;
        public RelayCommand GoFoEN => p.FOPageEN;
        public RelayCommand SettingEN => p.SettingPageEN;
        public RelayCommand GoBack => p.Tilbage;
        public RelayCommand GoToOpretRute => p.OpretRute;
        public RelayCommand GoToOpretRuteEN => p.OpretRuteEN;
        public RelayCommand GoToSaveAddresse => p.GemAdresseEN;
        public RelayCommand GoToGemAdresse => p.GemAdresse;
        public RelayCommand GoToSpecficRoute => p.GoToSpecificRutePage;
        public RelayCommand GOPasO => p.GOPasO;
        //user
        public Users UserCurrent => _uvm.UserCurrent;

        // routes
        public RelayCommand HandleSelectionRoute => _handleR;
        public ObservableCollection<Route> Ruter => _ruter;
        public ralaycommand2 LoadRute => _loadRute;
        public RelayCommand SaveRute => _saveRute;
        public RelayCommand LoadRoutes => _loadRoute;
        public RelayCommand UpdateOneRute => _updateOneRute;
        public RelayCommand DeleteOneRute => _deleteOneRute;
        public RelayCommand CreateOneRute => _createOneRute;
        public RelayCommand ClearCreateOneRutes => _clearCreateOneRute;
        public Route SelectedRute
        {
            get { return x.SelectedRute; }
            set
            {
                if (x.SelectedRute != value)
                    x.SelectedRute = value;
                HandleSelectedItem();
            }
        }


        public Route RouteToBeCreated
        {
            get => _ruteToBeCreated;
            set
            {
                _ruteToBeCreated = value;
                if (_selectedRute != null)
                    OnPropertyChanged();
            }
        }

        // passenger
        public ObservableCollection<Passenger> Passengers => _passengers;
        public RelayCommand LoadPassenger => _loadPassenger;
        public RelayCommand SavePassenger => _savePassenger;
        public RelayCommand UpdateOnePassengerAccept => _updateOnePassengerAcc;
        public RelayCommand UpdateOnePassengerDecline => _updateOnePassengerDec;
        public RelayCommand DeleteOnePassenger => _deleteOnePassenger;
        public RelayCommand CreateOnePassenger => _createOnePassenger;
        public RelayCommand ClearCreateOnePassenger => _clearCreateOnePassenger;
        public Passenger SelectedPassenger
        {
            get => _selectedPassenger;
            set
            {
                if (Equals(value, _selectedPassenger)) return;
                _selectedPassenger = value;
                OnPropertyChanged();
            }
        }
        public Passenger PassengerToBeCreated
        {
            get => _passengerToBeCreated;
            set
            {
                if (Equals(value, _passengerToBeCreated)) return;
                _passengerToBeCreated = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand LoadCurrentPas => _loadCurrentPassenger;
        //cars
        public ObservableCollection<Car> Cars => _cars;
        public RelayCommand LoadCar => _loadCars;
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
        //user 
        public RelayCommand LoadUser => _uvm.LoadUser;
        public ObservableCollection<Users> Users=> _uvm.Users;
        #endregion

        #region Method

        // routes


        private async void OpretRute1()
        {

            //todo give error message
            _ruteToBeCreated.starttime = $"{_ruteToBeCreated.hour} : {_ruteToBeCreated.minute}";
            _ruteToBeCreated.carId = _selectedCar.id;
            // _ruteToBeCreated.date = $"{_ruteToBeCreated.";
            await _persistenceRoute.Opret(_ruteToBeCreated);

            //_ruter.Add(_ruteToBeCreated);
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(OverviewPage));
        }
        private async void LoadRoute()
        {
            _ruter.Clear();
            var liste = await _persistenceRoute.Load();
            foreach (Route r in liste)
            {
                _ruter.Add(r);
            }
        }
        private async void LoadRutes(object e, object s)
        {
            _ruter.Clear();
            var liste = await _persistenceRoute.Load();
            foreach (Route r in liste)
            {
                _ruter.Add(r);
            }
            LoadStuff();
        }

        private void UpdateRute()
        {
            if (_selectedRute != null)
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
        private void HandleSelectedItem()
        {
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(SpecificRoutePage));
        }

        // passenger

        private async void OpretPassenger()
        {

            //todo give error message
            await _persistencePassenger.Opret(_passengerToBeCreated);
            //Frame f = (Frame)Window.Current.Content;
            //f.Navigate(typeof(OverviewPage));
        }
        private async void LoadPassengers()
        {
            _passengers.Clear();
            var liste = await _persistencePassenger.Load();
            foreach (Passenger p in liste)
            {
                _passengers.Add(p);
            }
        }
        private void UpdatePassengerAccept()
        {
            if (_selectedPassenger != null)
            {
                SelectedPassenger.status = "Accepteret";
                //todo give error message
                _persistencePassenger.Update(_selectedPassenger);
            }
        }

        private void UpdatePassengerDecline()
        {
            if (_selectedPassenger != null)
            {
                SelectedPassenger.status = "Afvist";
                //todo give error message
                _persistencePassenger.Update(_selectedPassenger);
            }
        }

        private void DeletePassenger()
        {
            if (_selectedPassenger != null)
            {
                //todo give error message
                _persistencePassenger.Delete(_selectedPassenger);
                _passengers.Remove(_selectedPassenger);
            }
        }
        private void ClearCreatePassenger()
        {
            PassengerToBeCreated = new Passenger();
        }
        private async void LoadCars()
        {
            _cars.Clear();
            var liste = await _persistenceCar.Load();
            foreach (Car c in liste)
            {
                if (c.userId == UserCurrent.id)
                {
                    _cars.Add(c);
                }
            }
        }
        private async void LoadCurrentPassenger()
        {
            var liste0 = await _persistenceCar.Load();
            foreach (Car car in liste0)
            {
                if (UserCurrent.id == car.userId)
                {
                    _cars.Add(car);
                //}

                var liste1 = await _persistenceRoute.Load();
                    foreach (Route rute in liste1)
                    {
                        if (car.id == rute.carId)
                        {
                            _ruter.Add(rute);
                            //}

                            _passengers.Clear();
                            var liste = await _persistencePassenger.Load();
                            foreach (Passenger passenger in liste)
                            {
                                if (rute.id == passenger.routeId)
                                {
                                    _passengers.Add(passenger);
                                }

                            }
                        }
                    }
                }
            }
        }
        public async void LoadStuff()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 10);
            timer.Tick += new EventHandler<object>(LoadRutes);
            timer.Start();
        }

        // onpropertychanged

        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
