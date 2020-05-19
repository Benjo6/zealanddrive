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
using ZealandDrive.Persistens.Rute;
using ZealandDrive.View;

namespace ZealandDrive.VM
{
    class RouteVM : INotifyPropertyChanged
    {
        #region Instance
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
        #endregion
        #region Constructor
        public RouteVM()
        {
            _loadRute = new RelayCommand(LoadRutes);
            _ruteToBeCreated = new Route();
            _ruter = new ObservableCollection<Route>();
            _createOneRute = new RelayCommand(OpretRute1);
            _selectedRute = new Route();
            _updateOneRute = new RelayCommand(UpdateRute);
            _deleteOneRute = new RelayCommand(DeleteRute);
            _clearCreateOneRute = new RelayCommand(ClearCreateRute);
            _persistenceRoute = new DBPersistenceRute();

        }
        #endregion
        #region Properties
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
        #endregion
        #region Method
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

        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
