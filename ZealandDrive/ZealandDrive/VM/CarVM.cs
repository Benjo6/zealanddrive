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
        private PageCommand p;

        #endregion
        #region Constructor
            public CarVM()
            {
                _loadCar = new RelayCommand(LoadCars);
                _carToBeCreated = new Car();
                _cars = new ObservableCollection<Car>();
                _createOneCar = new RelayCommand(OpretCar);
                _selectedCar = new Car();
                _updateOneCar = new RelayCommand(UpdateCar);
                _deleteOneCar = new RelayCommand(DeleteCar);
                _clearCreateOneCar = new RelayCommand(ClearCreateCar);
                _persistenceCar = new DBPersistenceCar();

            }
            #endregion
        #region Properties
        public RelayCommand LoadCar => _loadCar;

        public RelayCommand SaveCar => _saveCar;

        public RelayCommand UpdateOneCar => _updateOneCar;

        public RelayCommand DeleteOneCar => _deleteOneCar;

        public RelayCommand CreateOneCar => _createOneCar;

        public RelayCommand ClearCreateOneCar => _clearCreateOneCar;
        public ObservableCollection<Car> Cars => _cars;

        public RelayCommand GoBack => p.Tilbage;

        public RelayCommand GoGemBiler => p.GemBiler;

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
            #endregion
            #region Method
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


            public event PropertyChangedEventHandler PropertyChanged;

            //[NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
}
