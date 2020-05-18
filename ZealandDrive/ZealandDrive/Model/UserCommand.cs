﻿using ClassLibrary;
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
using ZealandDrive.View;

namespace ZealandDrive.Model
{
    class UserCommand
    {
        #region Instance
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
        #endregion
        #region Constructor
        public UserCommand()
        {
            _loadUser = new RelayCommand(LoadUsers);
            _userToBeCreated = new Users();
            _createOne = new RelayCommand(OpretUser);
            _selectedUser = new Users();
            _updateOneUser = new RelayCommand(UpdateUser);
            _deleteOneUser = new RelayCommand(DeleteUser);
            _clearCreateOneUser = new RelayCommand(ClearCreateUser);
            _persistence = PersitenceFactory.GetPersistency(PersistenceType.Database);


        }
        #endregion
        #region Properties
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
        #endregion
        #region Method
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
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
