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
using ZealandDrive.Persistens.Rute;

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


        }

        #endregion

        #region Properties
        public RelayCommand GoGemBiler => c.GemBiler;
        public RelayCommand GoAOS => c.AOS;
        public RelayCommand GoGemteBiler => c.GemteBiler;
        public RelayCommand GoGemAdresse => c.GemAdresse;
        public RelayCommand GoGemteAdresse => c.GemteAdresse;
        public RelayCommand GoPI => c.PI;
        public RelayCommand GoPrivat => c.Privat;
        public RelayCommand GoSprog => c.Sprog;


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

        //Users
        public ObservableCollection<Users> Users => c.Users;
        public Users SelectedUser => c.SelectedUser;
        public Users UserToBeCreated => c.UserToBeCreated;
        public RelayCommand LoadUser => c.LoadUser;
        public RelayCommand Save => c.Save;
        public RelayCommand UpdateOne => c.UpdateOne;
        public RelayCommand DeleteOne => c.DeleteOne;
        public RelayCommand CreateOne => c.CreateOne;
        public RelayCommand ClearCreateOneUser => c.ClearCreateOneUser;

        //Car
        public ObservableCollection<Car> Cars => c.Cars;
        public Car SelectedCar => c.SelectedCar;
        public Car CarToBeCreated => c.CarToBeCreated;
        public RelayCommand LoadCar => c.LoadCar;
        public RelayCommand SaveCar => c.SaveCar;
        public RelayCommand UpdateOneCar => c.UpdateOneCar;
        public RelayCommand DeleteOneCar => c.DeleteOneCar;
        public RelayCommand CreateOneCar => c.CreateOneCar;
        public RelayCommand ClearCreateOneCar => c.ClearCreateOneCar;

        //Rute
        public ObservableCollection<Route> Ruter => c.Ruter;
        public Route SelectedRute => c.SelectedRute;
        public Route RouteToBeCreated => c.RouteToBeCreated;
        public RelayCommand LoadRute => c.LoadRute;
        public RelayCommand SaveRute => c.SaveRute;
        public RelayCommand UpdateOneRute => c.UpdateOneRute;
        public RelayCommand DeleteOneRute => c.DeleteOneRute;
        public RelayCommand CreateOneRute => c.CreateOneRute;
        public RelayCommand ClearCreateOneRutes => c.ClearCreateOneRutes;



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





        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
