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
using Org.BouncyCastle.Asn1.Ocsp;
using ZealandDrive.Common;
using ZealandDrive.Model;
using ZealandDrive.Persistens;
using ZealandDrive.Persistens.Rute;
using ZealandDrive.View;
using ZealandDrive.Persistens.Bil;
using ZealandDrive.Lists;
using ZealandDrive.View_Dk;

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

        // cars
        private IPersistens<Car> _persistenceCar;
        private CarVM _cvm;

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


            // car
            _cvm = new CarVM();
            _persistenceCar = new DBPersistenceCar();

            //user
            _uvm = new UserVM();

            //load
            
            LoadRoute();

        }

        #endregion
        #region Properties
        //cars 
        public Car SelectedCar => _cvm.SelectedCar;
        public RelayCommand LoadCar => _cvm.LoadIdCar;
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
        public RelayCommand GoFo => p.FOPage;
        public RelayCommand GoTilmeldteRuter => p.GoTilmeldteRuter;
        public Singleton Instance => x;
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


        //cars
        public RelayCommand LoadIdCar => _cvm.LoadIdCar;

        //user 
        public RelayCommand LoadUser => _uvm.LoadUser;
        public ObservableCollection<Users> Users => _uvm.Users;
        #endregion

        #region Method

        // routes


        private async void OpretRute1()
        {

            //todo give error message
            _ruteToBeCreated.starttime = $"{_ruteToBeCreated.hour} : {_ruteToBeCreated.minute}";
            _ruteToBeCreated.carId = SelectedCar.id;
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
            //LoadStuff();
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
