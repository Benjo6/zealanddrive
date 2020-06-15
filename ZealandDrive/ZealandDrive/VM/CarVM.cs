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
using ZealandDrive.View;

namespace ZealandDrive.VM
{
    class CarVM : INotifyPropertyChanged
    {
        #region Instance
        //Singleton
        private Singleton x;
        //Page
        private PageCommand p;
        //Car
        private IPersistens<Car> _persistenceCar;
        private ObservableCollection<Car> _cars;
        private Car _selectedCar;
        private Car _carToBeCreated;
        private Car _carTobeUpdated;
        private RelayCommand _loadCars;

        private RelayCommand _saveCar;
        private RelayCommand _updateOneCar;
        private RelayCommand _deleteOneCar;
        private RelayCommand _clearCreateOneCar;
        private RelayCommand _createOneCar;

        private RelayCommand _loadOneCar;
        //route
        private RouteVM _rvm;

        #endregion
        #region Constructor
        public CarVM()
        {
            //Singleton
            x = Singleton.Instance;
            // page
            p = new PageCommand();
            //car
            _carToBeCreated = new Car();
            _cars = new ObservableCollection<Car>();
            _createOneCar = new RelayCommand(OpretCar);
            _selectedCar = new Car();
            _updateOneCar = new RelayCommand(UpdateCar);
            _deleteOneCar = new RelayCommand(DeleteCar);
            _clearCreateOneCar = new RelayCommand(ClearCreateCar);
            _persistenceCar = new DBPersistenceCar();
            _loadOneCar = new RelayCommand(LoadOneCars);

            _loadCars = new RelayCommand(LoadCars);
            //viewmodels
            //_rvm = new RouteVM();
            //load
            LoadOneCars();

        }
        #endregion
        #region Properties
        //route
        public Route SelectedRoute => _rvm.SelectedRute;
        //
        public Users UserCurrent => x.UserCurrent;
        //page
        public RelayCommand GOPasO => p.GOPasO;
        public RelayCommand GoTilmeldteRuter => p.GoTilmeldteRuter;
        public RelayCommand GoFOO => p.FOOPage;
        public RelayCommand GoGemteBiler => p.GemBiler;
        public RelayCommand GoBack => p.Tilbage;
        public RelayCommand GoGemBiler => p.GemBiler;
        public RelayCommand GoGemteBilerEN => p.GemteBilerEN;
        public RelayCommand GoToOverview => p.GoOverviewPage;
        public RelayCommand GoToOverviewEN => p.GoOverviewPageEN;
        public RelayCommand Setting => p.SettingPage;
        public RelayCommand SettingEN => p.SettingPageEN;
        //car
        public RelayCommand LoadOneCar => _loadOneCar;
        public RelayCommand LoadCar => _loadCars;

        public Car CarToBeUpdated
        {
            get => _carToBeCreated;
            set
            {
                if (Equals(value, _carTobeUpdated)) return;
                {
                    _carTobeUpdated = value;
                    OnPropertyChanged();
                }
            }
        }
        public RelayCommand SaveCar => _saveCar;

        public RelayCommand UpdateOne => _updateOneCar;

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

        //public Car CarToBeUpdated
        //{
        //    get => _carToBeCreated;
        //    set
        //    {
        //        if (Equals(value, _carTobeUpdated)) return;
        //        {
        //            _carTobeUpdated = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        #endregion
        #region Method

        private async void LoadOneCars()
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
        private async void LoadCars()
        {
            _cars.Clear();
            var liste = await _persistenceCar.Load();
            foreach (Car c in liste)
            {
                _cars.Add(c);
            }
        }

        private async void OpretCar()
        {
            _carToBeCreated.userId = UserCurrent.id;
            //todo give error message
            await _persistenceCar.Opret(_carToBeCreated);

            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(OverviewPage));
        }
        private async void UpdateCar()
        {
            if (_selectedCar != null)
            {
                _selectedCar.userId = UserCurrent.id;
                //todo give error message
                await _persistenceCar.Update(_selectedCar);
                LoadOneCars();
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




        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
