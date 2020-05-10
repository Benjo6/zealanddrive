using Prism.Commands;
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
using ZealandDrive.CommandPattern;
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


        private ICC _iCC;

        private readonly SharedKnowledge _shared;
        private RCO _nextCommand;
        #endregion

        #region Constructor
        public MainVM()
        {
            x = Singleton.Instance;
            lists = new Listerne();
            c = new Commands();

            ApplicationCommands = _iCC; ;
            _addRuter = new RelayCommand(AddRute);
            TilføjRute = new DelegateCommand(_addRuter);
            ApplicationCommands.OpretRuteCommand.RegisterCommand(_addRuter);

            

            _addRuteCommand = new RelayCommand(AddRute);

            _nextCommand = new RCO(Next);
            _shared = SharedKnowledge.Instance;

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

        public ICC ApplicationCommands
        {
            get { return _iCC; }
            set { _iCC = value; }
        }
        public RelayCommand AddRuter {get => _addRuter;}


        public RelayCommand AddRuter { get => _addRuteCommand; }

        public CompositeCommand OpretRuteKnap => altiind;

        public SharedKnowledge Instance
        {
            get { return _shared; }
        }
        public RCO NextCommand
        {
            get { return _nextCommand; }
        }
        public ObservableCollection<Rute> rutes
        { get { return _rutes; } }


        #endregion

        #region Method

        public void AddRute()
        {
            Ruter.Add(NyRute);
        }

        private void Next(object obj)
        {
            var rutePair = (KeyValuePair<int, Rute>)obj;
            _shared.SelectedRute = rutePair.Value;

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
