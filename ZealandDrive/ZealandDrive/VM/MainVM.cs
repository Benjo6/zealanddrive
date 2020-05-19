﻿using ClassLibrary;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ZealandDrive.Common;
using ZealandDrive.Lists;
using ZealandDrive.Model;
using ZealandDrive.View;
using Windows.Web.Http;
using System.Windows.Input;

namespace ZealandDrive.VM
{
    class MainVM : INotifyPropertyChanged
    {
        #region Instance

        private CarCommand c;
        private ForumCommand f;
        private PageCommand p;
        private RuteCommand r;
        private UserCommand u;
        private Singleton x;
        private Listerne lists;

        private ObservableCollection<string> _adresseList;

        private bool isChecked;
        private ICommand checkCommand;


        private RCO _nextCommand;
        private RCO _next1Command;
        #endregion

        #region Constructor
        public MainVM()
        {

            _adresseList = new ObservableCollection<string>();

            x = Singleton.Instance;
            lists = new Listerne();
            c = new CarCommand();
            f = new ForumCommand();
            p = new PageCommand();
            r = new RuteCommand();
            u = new UserCommand();
            _nextCommand = new RCO(Next);
            _next1Command = new RCO(Next1);


        }

        #endregion

        #region Properties
        public RelayCommand GoGemBiler => p.GemBiler;
        public RelayCommand GoAOS => p.AOS;
        public RelayCommand GoGemteBiler => p.GemteBiler;
        public RelayCommand GoGemAdresse => p.GemAdresse;
        public RelayCommand GoGemteAdresse => p.GemteAdresse;
        public RelayCommand GoPI => p.PI;
        public RelayCommand GoPrivat => p.Privat;
        public RelayCommand GoSprog => p.Sprog;
        public RelayCommand GoFo => p.FOPage;
        public RelayCommand GoFOO => p.FOOPage;
        public RelayCommand UserTest => p.UserTest;

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        //public ICommand CheckCommand
        //{
        //    get
        //    {
        //        if (checkCommand == null)
        //            checkCommand = new RelayCommand(Checkprocess(), null);
        //        return checkCommand;
        //    }
        //    set
        //    {
        //        checkCommand = value;
        //        OnPropertyChanged("CheckCommand");
        //    }
        //}

        public RelayCommand GoToOpretBruger => p.Opret;

        public ObservableCollection<string> H => lists.Timer;

        public ObservableCollection<string> M => lists.Minutter;

        public RelayCommand GoToLogin => p.Login;

        public RelayCommand GoToOpretRute => p.OpretRute;

        public RelayCommand GoToOverview => p.GoOverviewPage;

        public RelayCommand GoBack => p.Tilbage;

        public Singleton Instance => x;

        public RelayCommand Setting => p.SettingPage;
        
        public RCO NextCommand
        {
            get { return _nextCommand; }
        }

        public RCO Next1Command => _next1Command;
        //Users
        public ObservableCollection<Users> Users => u.Users;
        public Users SelectedUser => u.SelectedUser;
        public Users UserToBeCreated => u.UserToBeCreated;
        public RelayCommand LoadUser => u.LoadUser;
        public RelayCommand Save => u.Save;
        public RelayCommand UpdateOne => u.UpdateOne;
        public RelayCommand DeleteOne => u.DeleteOne;
        public RelayCommand CreateOne => u.CreateOne;
        public RelayCommand ClearCreateOneUser => u.ClearCreateOneUser;

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
        public ObservableCollection<Route> Ruter => r.Ruter;
        public Route SelectedRute => r.SelectedRute;
        public Route RouteToBeCreated => r.RouteToBeCreated;
        public RelayCommand LoadRute => r.LoadRute;
        public RelayCommand SaveRute => r.SaveRute;
        public RelayCommand UpdateOneRute => r.UpdateOneRute;
        public RelayCommand DeleteOneRute => r.DeleteOneRute;
        public RelayCommand CreateOneRute => r.CreateOneRute;
        public RelayCommand ClearCreateOneRutes => r.ClearCreateOneRutes;
        //Forum
        public ObservableCollection<Forum> Forum => f.Forum;
        public Forum SelectedForum => f.SelectedForum;
        public Forum ForumToBeCreated => f.ForumToBeCreated;
        public RelayCommand LoadForum => f.LoadForum;
        public RelayCommand SaveForum => f.SaveForum;
        public RelayCommand UpdateOneForum => f.UpdateOneForum;
        public RelayCommand DeleteOneForum => f.DeleteOneForum;
        public RelayCommand CreateOneForum => f.CreateOneForum;
        public RelayCommand ClearCreateOneForum => f.ClearCreateOneForum;



        #endregion

        #region Method
        //public void Checkprocess(object sender)
        //{
        //    if (CheckCommand.IsChecked)
        //    {
        //        HttpCookie cookie = new HttpCookie();
        //        cookie.Values.Add(“username”, txtUsername.Text);
        //        cookie.Expires = DateTime.Now.AddDays(15);
        //        Response.Cookies.Add(cookie);
        //    }
        //}



        private void Next(object obj)
        {
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(SpecificRoutePage));
        }

        private void Next1(object obj)
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
