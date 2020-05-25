using ClassLibrary;
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
using System.Collections.Generic;

namespace ZealandDrive.VM
{
    class MainVM : INotifyPropertyChanged
    {
        #region Instance
        private readonly PageCommand p;
        private readonly Singleton x;
        private readonly Listerne lists;
        private readonly RCO _nextCommand;
        private readonly RCO _next1Command;

        #endregion

        #region Constructor
        public MainVM()
        {
            x = Singleton.Instance;
            lists = new Listerne();
            p = new PageCommand();
            _nextCommand = new RCO(Next);
            _next1Command = new RCO(Next1);

        }

        #endregion

        #region Properties
        public RelayCommand GoGemBiler => p.GemBiler;
        public RelayCommand GOPasO => p.GOPasO;
        public RelayCommand GoAOS => p.AOS;
        public RelayCommand GoGemteBiler => p.GemteBiler;
        public RelayCommand GoGemAdresse => p.GemAdresse;
        public RelayCommand GoGemteAdresse => p.GemteAdresse;
        public RelayCommand GoPI => p.PI;
        public RelayCommand GoPrivat => p.Privat;
        public RelayCommand GoSprog => p.Sprog;
        public RelayCommand GoFo => p.FOPage;
        public RelayCommand GoFOO => p.FOOPage;
        public RelayCommand GoGemBilerEN => p.GemBilerEN;
        public RelayCommand GoAOSEN => p.AOSEN;
        public RelayCommand GoGemteBilerEN => p.GemteBilerEN;
        public RelayCommand GoGemAdresseEN => p.GemAdresseEN;
        public RelayCommand GoGemteAdresseEN => p.GemteAdresseEN;
        public RelayCommand GoPIEN => p.PIEN;
        public RelayCommand GoPrivatEN => p.PrivatEN;
        public RelayCommand GoSprogEN => p.SprogEN;
        public RelayCommand GoFoEN => p.FOPageEN;
        public RelayCommand GoFOOEN => p.FOOPageEN;
        public RelayCommand GoOverview => p.GoOverviewPage;
        public RelayCommand GoOverviewEN => p.GoOverviewPage;

        public ObservableCollection<string> H => lists.Timer;

        public ObservableCollection<string> M => lists.Minutter;

        public RelayCommand GoToLogin => p.Login;

        public RelayCommand GoToOpretRute => p.OpretRute;

        

        public RelayCommand GoBack => p.Tilbage;

        public Singleton Instance => x;

        public RelayCommand Setting => p.SettingPage;
        public RelayCommand SettingEN => p.SettingPageEN;


        public RCO NextCommand
        {
            get { return _nextCommand; }
        }

        public RCO Next1Command => _next1Command;

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
