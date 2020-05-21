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

namespace ZealandDrive.VM
{
    class RouteVM : INotifyPropertyChanged
    {
        #region Instance

        // Page
        private PageCommand p;
        private RCO _nextCommand;
        private Singleton x;
        // Routes
        private IPersistens<Route> _persistenceRoute;
        private RelayCommand _createOneRute;
        private Route _selectedRute;
        private RelayCommand _loadRute;
        private Route _ruteToBeCreated;
        private RelayCommand _saveRute;
        private RelayCommand _updateOneRute;
        private RelayCommand _deleteOneRute;
        private RelayCommand _clearCreateOneRute;
        private ObservableCollection<Route> _ruter;

        // passenger
        private IPersistens<Passenger> _persistencePassenger;
        private RelayCommand _createOnePassenger;
        private Passenger _selectedPassenger;
        private RelayCommand _loadPassenger;
        private Passenger _passengerToBeCreated;
        private RelayCommand _savePassenger;
        private RelayCommand _updateOnePassenger;
        private RelayCommand _deleteOnePassenger;
        private RelayCommand _clearCreateOnePassenger;
        private ObservableCollection<Passenger> _passengers;

        // cars
        private IPersistens<Car> _persistenceCar;
        private ObservableCollection<Car> _cars;
        private RelayCommand _loadCars;
        private Car _selectedCar;

        #endregion
        #region Constructor
        public RouteVM()
        {
            //page
            p = new PageCommand();
            // routes
            x = Singleton.Instance;
            _loadRute = new RelayCommand(LoadRutes);
            _ruteToBeCreated = new Route();
            _ruter = new ObservableCollection<Route>();
            _createOneRute = new RelayCommand(OpretRute1);
            _selectedRute = new Route();
            _updateOneRute = new RelayCommand(UpdateRute);
            _deleteOneRute = new RelayCommand(DeleteRute);
            _clearCreateOneRute = new RelayCommand(ClearCreateRute);
            _persistenceRoute = new DBPersistenceRute();
            _nextCommand = new RCO(Next);
            // passenger
            _loadPassenger = new RelayCommand(LoadPassengers);
            _passengerToBeCreated = new Passenger();
            _passengers = new ObservableCollection<Passenger>();
            _createOnePassenger = new RelayCommand(OpretPassenger);
            _selectedPassenger = new Passenger();
            _updateOnePassenger = new RelayCommand(UpdatePassenger);
            _deleteOnePassenger = new RelayCommand(DeletePassenger);
            _clearCreateOnePassenger = new RelayCommand(ClearCreatePassenger);
            _persistencePassenger = new DBPersistencePassenger();
            // car
            _selectedCar = new Car();
            _loadCars = new RelayCommand(LoadCars);
            _cars = new ObservableCollection<Car>();
        }
        #endregion
        #region Properties
        // page
        public Singleton Instance => x;
        public RelayCommand GoToOverview => p.GoOverviewPage;
        public RelayCommand GoFo => p.FOPage;
        public RelayCommand Setting => p.SettingPage;

        public RelayCommand GoToOverviewEN => p.GoOverviewPageEN;
        public RelayCommand GoFoEN => p.FOPageEN;
        public RelayCommand SettingEN => p.SettingPageEN;
        public RelayCommand GoBack => p.Tilbage;
        public RelayCommand GoToOpretRute => p.OpretRute;
        public RelayCommand GoToOpretRuteEN => p.OpretRuteEN;
        public RelayCommand GoToSaveAddresse => p.GemAdresseEN;
        public RelayCommand GoToGemAdresse => p.GemAdresse;


        public RCO NextCommand
        {
            get { return _nextCommand; }
        }


        // routes
        public ObservableCollection<Route> Ruter => _ruter;
        public RelayCommand LoadRute => _loadRute;
        public RelayCommand SaveRute => _saveRute;
        public RelayCommand UpdateOneRute => _updateOneRute;
        public RelayCommand DeleteOneRute => _deleteOneRute;
        public RelayCommand CreateOneRute => _createOneRute;
        public RelayCommand ClearCreateOneRutes => _clearCreateOneRute;
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

        // passenger
        public ObservableCollection<Passenger> Passengers => _passengers;
        public RelayCommand LoadPassenger => _loadPassenger;
        public RelayCommand SavePassenger => _savePassenger;
        public RelayCommand UpdateOnePassenger => _updateOnePassenger;
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

        #endregion

        #region Method

        // routes

        private void Next(object obj)
        {
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(SpecificRoutePage));
        }
        private async void OpretRute1()
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
        private void UpdatePassenger()
        {
            if (_selectedPassenger != null)
            {
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
        // cars
        private async void LoadCars()
        {
            _cars.Clear();
            var liste = await _persistenceCar.Load();
            foreach (Car c in liste)
            {
                _cars.Add(c);
            }
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
