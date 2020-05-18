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
using ZealandDrive.Persistens;
using ZealandDrive.Persistens.Bil;
using ZealandDrive.Persistens.Rute;
using ZealandDrive.Persistens.Forum;
using ZealandDrive.View;
using ZealandDrive.VM;


namespace ZealandDrive.Model
{
    class Commands
    {
        #region Instance
        private NavigationService navigationService;
        //Sideskrift
        public RelayCommand loginPage;
        public RelayCommand oRutePage;
        public RelayCommand overviewPage;
        public RelayCommand tilbagePage;
        public RelayCommand sRutePage;
        public RelayCommand settingPage;
        public RelayCommand opretBruger;
        private RelayCommand aOS;
        private RelayCommand gemadresse;
        private RelayCommand gemBiler;
        private RelayCommand gemteadresser;
        private RelayCommand gemteBiler;
        private RelayCommand personligeinf;
        private RelayCommand privat;
        private RelayCommand sprog;
        private RelayCommand fo;
        private RelayCommand foo;
        //User
        private IPersistens<Users> _persistence;
        private RelayCommand _createOne;
        private RelayCommand _loadUser;
        private RelayCommand _saveUser;
        private RelayCommand _updateOneUser;
        private RelayCommand _deleteOneUser;
        private RelayCommand _clearCreateOneUser;
        private Users _userToBeCreated;
        private Users _selectedUser;
        private ObservableCollection<Users> _users;
        //Car
        private IPersistens<Car> _persistenceCar;
        private RelayCommand _createOneCar;
        private Car _selectedCar;
        private RelayCommand _loadCar;
        private Car _carToBeCreated;
        private ObservableCollection<Car> _cars;
        private RelayCommand _saveCar;
        private RelayCommand _updateOneCar;
        private RelayCommand _deleteOneCar;
        private RelayCommand _clearCreateOneCar;
        //Route
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
        //Forum
       // private IPersistens<Forum> _persistenceForum;
        private RelayCommand _createOneForum;
      //  private Forum _selectedForum;
        private RelayCommand _loadForum;
       // private Forum _forumToBeCreated;
        private RelayCommand _saveForum;
        private RelayCommand _updateOneForum;
        private RelayCommand _deleteOneForum;
        private RelayCommand _clearCreateOneForum;
        private ObservableCollection<Route> _forum;

        #endregion

        #region Constructor
        public Commands()
        {
            //Sideskift
            navigationService = new NavigationService();
            loginPage = new RelayCommand(GotoLogin);
            oRutePage = new RelayCommand(GotoOpretRute);
            overviewPage = new RelayCommand(GotoOverview);
            tilbagePage = new RelayCommand(GoBack);
            sRutePage = new RelayCommand(GotoSpecificRutePage);
            settingPage = new RelayCommand(GoSetting);
            opretBruger = new RelayCommand(GotoOpretBruger);
            aOS = new RelayCommand(GOAOS);
            gemadresse = new RelayCommand(GOGemAdresse);
            gemBiler = new RelayCommand(GOGemBil);
            gemteadresser = new RelayCommand(GOGemteAdresse);
            gemteBiler = new RelayCommand(GOGemteBil);
            personligeinf = new RelayCommand(GoPersonligeInformation);
            privat = new RelayCommand(GoPrivatlivsindstillinger);
            sprog = new RelayCommand(GoSprog);
            fo = new RelayCommand(GoFO);
            foo = new RelayCommand(GoFOO);

            //User
            _loadUser = new RelayCommand(LoadUsers);
            _userToBeCreated = new Users();
            _createOne = new RelayCommand(OpretUser);
            _selectedUser = new Users();
            _updateOneUser = new RelayCommand(UpdateUser);
            _deleteOneUser = new RelayCommand(DeleteUser);
            _clearCreateOneUser = new RelayCommand(ClearCreateUser);

            //Car
            _loadCar = new RelayCommand(LoadCars);
            _carToBeCreated = new Car();
            _cars = new ObservableCollection<Car>();
            _createOneCar = new RelayCommand(OpretCar);
            _selectedCar = new Car();
            _updateOneCar = new RelayCommand(UpdateCar);
            _deleteOneCar = new RelayCommand(DeleteCar);
            _clearCreateOneCar = new RelayCommand(ClearCreateCar);

            //Rute
            _loadRute = new RelayCommand(LoadRutes);
            _ruteToBeCreated = new Route();
            _ruter = new ObservableCollection<Route>();
            _createOneRute = new RelayCommand(OpretRute1);
            _selectedRute = new Route();
            _updateOneRute = new RelayCommand(UpdateRute);
            _deleteOneRute = new RelayCommand(DeleteRute);
            _clearCreateOneRute = new RelayCommand(ClearCreateRute);

            //Forum
            //_loadForum = new RelayCommand(LoadForum);
            //_forumToBeCreated = new Route();
            //_forum = new ObservableCollection<Route>();
            //_createOneForum = new RelayCommand(OpretForum1);
            //_selectedForum = new Route();
            //_updateOneForum = new RelayCommand(UpdateForum);
            //_deleteOneForum = new RelayCommand(DeleteForum);
            //_clearCreateOneForum = new RelayCommand(ClearCreateForum);

            //Persistence
            _persistence = PersitenceFactory.GetPersistency(PersistenceType.Database);
            _persistenceCar = new DBPersistenceCar();
            //_persistenceRoute = new DBPersistenceRute();
           // _persistenceForum = new DBPersistenceForum();

        }
        #endregion

        #region Properties
        //User
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

        public RelayCommand LoadUser => _loadUser;

        public RelayCommand Save => _saveUser;

        public RelayCommand UpdateOne => _updateOneUser;

        public RelayCommand DeleteOne => _deleteOneUser;

        public RelayCommand CreateOne => _createOne;

        public RelayCommand ClearCreateOneUser => _clearCreateOneUser;


        //Car
        public RelayCommand LoadCar => _loadCar;

        public RelayCommand SaveCar => _saveCar;

        public RelayCommand UpdateOneCar => _updateOneCar;

        public RelayCommand DeleteOneCar => _deleteOneCar;

        public RelayCommand CreateOneCar => _createOneCar;

        public RelayCommand ClearCreateOneCar => _clearCreateOneCar;
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

        //Rute
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

        //Forum
        //public ObservableCollection<Forum> Forum => _forum;
        //public RelayCommand LoadForum => _loadForum;
        public RelayCommand SaveForum => _saveForum;
        public RelayCommand UpdateOneForum => _updateOneForum;
        public RelayCommand DeleteOneForum => _deleteOneForum;
        public RelayCommand CreateOneForum => _createOneForum;
        public RelayCommand ClearCreateOneForum => _clearCreateOneForum;
        //public Forum SelectedForum
        //{
        //    get => _selectedRute;
        //    set
        //    {
        //        if (Equals(value, _selectedRute)) return;
        //        _selectedRute = value;
        //        OnPropertyChanged();
        //    }
        //}
        //public Forum ForumToBeCreated
        //{
        //    get => _ruteToBeCreated;
        //    set
        //    {
        //        if (Equals(value, _ruteToBeCreated)) return;
        //        _ruteToBeCreated = value;
        //        OnPropertyChanged();
        //    }
        //}
        //Sideskift
        public RelayCommand GemAdresse => gemadresse;
        public RelayCommand GemteAdresse => gemteadresser;
        public RelayCommand GemBiler => gemBiler;
        public RelayCommand GemteBiler => gemteBiler;
        public RelayCommand PI => personligeinf;
        public RelayCommand Privat => privat;
        public RelayCommand Sprog => sprog;

        public RelayCommand Login
        {
            get
            {
                return loginPage;
            }
        }

        public RelayCommand Opret
        {
            get
            {
                return opretBruger;
            }
        }

        public RelayCommand GoToSpecificRutePage
        {
            get
            {
                return sRutePage;
            }
        }
        public RelayCommand AOS => aOS;

        public RelayCommand OpretRute => oRutePage;

        public RelayCommand GoOverviewPage => overviewPage;

        public RelayCommand Tilbage => tilbagePage;

        //public RelayCommand test => sRutePage;

        public RelayCommand SRutePage => GoToSpecificRutePage;

        public RelayCommand SettingPage => settingPage;
        public RelayCommand FOPage => fo;
        public RelayCommand FOOPage => foo;

        #endregion


        #region Method
        //Forum Commands
        //private async void OpretForum1()
        //{

        //    //todo give error message
        //    await _persistenceRoute.Opret(_forumToBeCreated);

        //    //_users.Add(_userToBeCreated);
        //    Frame f = (Frame)Window.Current.Content;
        //    f.Navigate(typeof(View.ForumOverview));
        //}
        //private async void LoadForum()
        //{
        //    _ruter.Clear();
        //    var liste = await _persistenceForum.Load();
        //    foreach (Forum r in liste)
        //    {
        //        _ruter.Add(r);
        //    }
        //}
        //private void UpdateForum()
        //{
        //    if (_selectedUser != null)
        //    {
        //        //todo give error message
        //        _persistenceForum.Update(_selectedForum);
        //    }
        //}
        //private void DeleteForum()
        //{
        //    if (_selectedRute != null)
        //    {
        //        //todo give error message
        //        _persistenceForum.Delete(_selectedForum);
        //        _forum.Remove(_selectedForum);
        //    }
        //}
        //private void ClearCreateForum()
        //{
        //    ForumToBeCreated = new Forum();
        //}


        //Rute Commands
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
        //Bil Commands
        private async void OpretCar()
        {

            //todo give error message
            await _persistenceCar.Opret(_carToBeCreated);

            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(OverviewPage));

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


        //User Commands
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

        //Page Switch
        public void GoSetting()
        {
            navigationService.navigate(typeof(View.Settings));

        }
        public void GoFO()
        {
            navigationService.navigate(typeof(View.ForumOverview));

        }
        public void GoFOO()
        {
            navigationService.navigate(typeof(View.OpretForum));

        }
        public void GoBack()
        {
            var frame = (Frame)Window.Current.Content;
            if (frame.CanGoBack)
                frame.GoBack();
        }

        public void GotoLogin()
        {
            {
                navigationService.navigate(typeof(View.LoginPage));
            }
        }
        public void GotoOpretRute()
        {
            {
                navigationService.navigate(typeof(View.OpretRutePage));
            }
        }
        public void GotoOverview()
        {
            {
                navigationService.navigate(typeof(View.OverviewPage));
            }
        }

        public void GotoSpecificRutePage()
        {
            {
                navigationService.navigate(typeof(View.SpecificRoutePage));
            }
        }

        public void GotoOpretBruger()
        {
            {
                navigationService.navigate(typeof(View.OpretBruger));
            }
        }
        public void GOAOS()
        {
            {
                navigationService.navigate(typeof(View.AdgangskodeogSikkerhed));
            }
        }
        public void GOGemAdresse()
        {
            {
                navigationService.navigate(typeof(View.GemRute));
            }
        }
        public void GOGemBil()
        {
            {
                navigationService.navigate(typeof(View.GemBiler));
            }
        }
        public void GOGemteBil()
        {
            {
                navigationService.navigate(typeof(View.GemteBiler));
            }
        }
        public void GOGemteAdresse()
        {
            {
                navigationService.navigate(typeof(View.GemteAdresser));
            }
        }
        public void GoPersonligeInformation()
        {
            {
                navigationService.navigate(typeof(View.PersonligeInformation));
            }
        }
        public void GoPrivatlivsindstillinger()
        {
            {
                navigationService.navigate(typeof(View.Privatlivsindstillinger));
            }
        }
        public void GoSprog()
        {
            {
                navigationService.navigate(typeof(View.Sprog));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            #endregion
        }
    }
}
