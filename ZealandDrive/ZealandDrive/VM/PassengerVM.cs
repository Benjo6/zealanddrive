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
using ZealandDrive.Persistens.Bil;
using ZealandDrive.Persistens.Bruger;
using ZealandDrive.Persistens.Rute;
using ZealandDrive.View_Dk;

namespace ZealandDrive.VM
{
    class PassengerVM
    {
        //instance fields
        #region Instancefields
        private readonly PageCommand p;
        private UserVM _uvm;
        private RouteVM _rvm;
        private CarVM _cvm;

        //private ForumVM _fvm;
        //private SprogVM _svm;
        //private MainVM _mvm;

        // passenger
        private IPersistens<Passenger> _persistencePassenger;
        private RelayCommand _createOnePassenger;
        private Passenger _selectedPassenger;
        private RelayCommand _loadPassenger;
        private RelayCommand _loadTilmeldteRuter;
        private Passenger _passengerToBeCreated;
        private RelayCommand _savePassenger;
        private RelayCommand _updateOnePassengerDec;
        private RelayCommand _updateOnePassengerAcc;
        private RelayCommand _updateOnePassengerCheckInd;
        private RelayCommand _deleteOnePassenger;
        private RelayCommand _clearCreateOnePassenger;
        private ObservableCollection<Passenger> _passengers;
        private RelayCommand _loadCurrentPassenger;
        //car
        private IPersistens<Car> _persistenceCar;
        //user
        private IPersistens<Users> _persistensUser;
        //route
        private IPersistens<Route> _persistensRoute;
        #endregion
        //Constructor
        #region Constructor

        public PassengerVM()
        {
            //view models
            _uvm = new UserVM();
            _rvm = new RouteVM();
            _cvm = new CarVM();
            p = new PageCommand();
            //_fvm = new ForumVM();
            //_svm = new SprogVM();
            //_mvm = new MainVM();

            //persistens
            _persistenceCar = new DBPersistenceCar();
            _persistensUser = new DBPersistence();
            _persistencePassenger = new DBPersistencePassenger();
            _persistensRoute = new DBPersistenceRute();

            // passenger
            _loadPassenger = new RelayCommand(LoadPassengers);
            _passengerToBeCreated = new Passenger();
            _passengers = new ObservableCollection<Passenger>();
            _createOnePassenger = new RelayCommand(OpretPassenger);
            _selectedPassenger = new Passenger();
            _updateOnePassengerAcc = new RelayCommand(UpdatePassengerAccept);
            _updateOnePassengerDec = new RelayCommand(UpdatePassengerDecline);
            _updateOnePassengerCheckInd = new RelayCommand(UpdateCheckInd);
            _deleteOnePassenger = new RelayCommand(DeletePassenger);
            _clearCreateOnePassenger = new RelayCommand(ClearCreatePassenger);
            _loadCurrentPassenger = new RelayCommand(LoadCurrentPassenger);
            _loadTilmeldteRuter = new RelayCommand(LoadTilmeldte);

            //load

            LoadTilmeldte();
            LoadCurrentPassenger();

        }

        #endregion

        //Properties
        #region Properties
        //page
        public RelayCommand GoFo => p.FOPage;
        public RelayCommand GoTilmeldteRuter => p.GoTilmeldteRuter;
        public RelayCommand GoToOverview => p.GoOverviewPage;
        public RelayCommand GoFOO => p.FOOPage;
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
        public Users CurrentUser => _uvm.UserCurrent;
        //ruter
        public ObservableCollection<Route> Ruter => _rvm.Ruter;
        public Route SelectedRoute => _rvm.SelectedRute;
        //cars
        public ObservableCollection<Car> Cars => _cvm.Cars;
        // passenger
        public ObservableCollection<Passenger> Passengers => _passengers;
        public RelayCommand LoadPassenger => _loadPassenger;
        public RelayCommand LoadTilmeldteRuter => _loadTilmeldteRuter;
        public RelayCommand SavePassenger => _savePassenger;
        public RelayCommand UpdateOnePassengerAccept => _updateOnePassengerAcc;
        public RelayCommand UpdateOnePassengerDecline => _updateOnePassengerDec;
        public RelayCommand UpdateOnePassengerCheckInd => _updateOnePassengerCheckInd;
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


        #endregion
        //Method

        #region Method
        // passenger

        private async void OpretPassenger()
        {
            _passengerToBeCreated.userId = CurrentUser.id;
            _passengerToBeCreated.routeId = SelectedRoute.id;
            _passengerToBeCreated.status = "Afventer Accept";
            //todo give error message
            await _persistencePassenger.Opret(_passengerToBeCreated);
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(TilmeldteRuter));
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
        private async void UpdatePassengerAccept()
        {
            if (_selectedPassenger != null)
            {
                SelectedPassenger.status = "Accepteret";
                //todo give error message
                await _persistencePassenger.Update(_selectedPassenger);
                await _persistencePassenger.Load();

            }
        }

        private async void UpdatePassengerDecline()
        {
            if (_selectedPassenger != null)
            {
                SelectedPassenger.status = "Afvist";
                //todo give error message
                await _persistencePassenger.Update(_selectedPassenger);
                await _persistencePassenger.Load();
            }
        }

        private async void UpdateCheckInd()
        {
            if (_selectedPassenger != null && _selectedPassenger.status == "Accepteret")
            {
                SelectedPassenger.status = "Checked in";
                await _persistencePassenger.Update(_selectedPassenger);
                await _persistencePassenger.Load();
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

        private async void LoadCurrentPassenger()
        {
            var liste0 = await _persistenceCar.Load();
            foreach (Car car in liste0)
            {
                if (CurrentUser.id == car.userId)
                {
                    Cars.Add(car);
                    //}

                    var liste1 = await _persistensRoute.Load();
                    foreach (Route rute in liste1)
                    {
                        if (car.id == rute.carId)
                        {
                            Ruter.Add(rute);
                            //}

                            //_passengers.Clear();
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

        private async void LoadTilmeldte()
        {
            _passengers.Clear();
            var liste = await _persistencePassenger.Load();
            foreach (Passenger pass in liste)
            {
                if (CurrentUser.id == pass.userId)
                {
                    _passengers.Add(pass);
                }
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
