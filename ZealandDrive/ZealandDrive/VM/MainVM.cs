﻿using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using ZealandDrive.Common;
using ZealandDrive.Lists;
using ZealandDrive.Model;
using ZealandDrive.View;

namespace ZealandDrive.VM
{
    class MainVM : INotifyPropertyChanged
    {
        #region Instance

        private Commands c;
        private Singleton x;
        private ObservableCollection<Rute> _rutes;
        private RelayCommand _addRuter;
        private DelegateCommand TilføjRute;
        private Rute _nyRute;
        private Listerne lists;
        private RCO _nextCommand;
        #endregion

        #region Constructor
        public MainVM()
        {
            x = Singleton.Instance;
            lists = new Listerne();
            c = new Commands();

            _addRuter = new RelayCommand(AddRute);

            //Rute test = new Rute("køge", "roskilde", "kia", "13", "00", DateTimeOffset.Now, "test");
            //_rutes.Add(test);




            _nextCommand = new RCO(Next);

        }

        #endregion

        #region Properties

        public ObservableCollection<string> H => lists.Timer;

        public ObservableCollection<string> M => lists.Minutter;


        public RelayCommand GoToLogin => c.Login;

        public Rute NyRute { get => x.NyRute; }

        public ObservableCollection<Rute> Ruter { get => x.Ruter; }

        public RelayCommand GoToOpretRute => c.OpretRute;

        public RelayCommand GoToOverview => c.GoOverviewPage;

        public RelayCommand GoBack => c.Tilbage;

        public Singleton Instance => x;


  
        public RelayCommand AddRuter {get => _addRuter;}

        
        public RCO NextCommand
        {
            get { return _nextCommand; }
        }



        #endregion

        #region Method

        public void AddRute()
        {
            Ruter.Add(NyRute);
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(OverviewPage));
        }

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
