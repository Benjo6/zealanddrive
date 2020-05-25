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
using ZealandDrive.Model;
using ZealandDrive.Persistens;
using ZealandDrive.Persistens.F;

namespace ZealandDrive.VM
{
    class ForumVM : INotifyPropertyChanged
    {
        #region Instance
        private readonly IPersistens<Forum> _persistenceForum;
        private readonly RelayCommand _createOneForum;
        private Forum _selectedForum;
        private readonly RelayCommand _loadForum;
        private Forum _forumToBeCreated;
        private readonly RelayCommand _saveForum;
        private readonly RelayCommand _updateOneForum;
        private readonly RelayCommand _deleteOneForum;
        private readonly RelayCommand _clearCreateOneForum;
        private readonly ObservableCollection<Forum> _forum;
        private readonly PageCommand p;
        #endregion
        #region Constructor
        public ForumVM()
        {
            _loadForum = new RelayCommand(LoadForum1);
            _forumToBeCreated = new Forum();
            _forum = new ObservableCollection<Forum>();
            _createOneForum = new RelayCommand(OpretForum1);
            _selectedForum = new Forum();
            _updateOneForum = new RelayCommand(UpdateForum);
            _deleteOneForum = new RelayCommand(DeleteForum);
            _clearCreateOneForum = new RelayCommand(ClearCreateForum);
            _persistenceForum = new DBPersistenceForum();
            p = new PageCommand();


        }
        #endregion
        #region Properties
        public RelayCommand GoToOverviewEN => p.GoOverviewPageEN;
        public RelayCommand GoToOverview => p.GoOverviewPage;
        public RelayCommand ForumPage => p.FOPage;
        public RelayCommand ForumPageEN => p.FOPageEN;
        public RelayCommand OpretForum => p.FOOPage;
        public RelayCommand CreateForum => p.FOOPageEN;
        public RelayCommand Setting => p.SettingPage;
        public RelayCommand SettingEN => p.SettingPageEN;
        

        public ObservableCollection<Forum> Forum => _forum;
        public RelayCommand LoadForum => _loadForum;
        public RelayCommand SaveForum => _saveForum;
        public RelayCommand UpdateOneForum => _updateOneForum;
        public RelayCommand DeleteOneForum => _deleteOneForum;
        public RelayCommand CreateOneForum => _createOneForum;
        public RelayCommand ClearCreateOneForum => _clearCreateOneForum;
        public Forum SelectedForum
        {
            get => _selectedForum;
            set
            {
                if (Equals(value, _selectedForum)) return;
                _selectedForum = value;
                OnPropertyChanged();
            }
        }
        public Forum ForumToBeCreated
        {
            get => _forumToBeCreated;
            set
            {
                if (Equals(value, _forumToBeCreated)) return;
                _forumToBeCreated = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Method
        private async void OpretForum1()
        {

            //todo give error message
            await _persistenceForum.Opret(_forumToBeCreated);

            //_users.Add(_userToBeCreated);
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(View.ForumOverview));
        }
        private async void LoadForum1()
        {
            _forum.Clear();
            var liste = await _persistenceForum.Load();
            foreach (Forum r in liste)
            {
                _forum.Add(r);
            }
        }
        private void UpdateForum()
        {
            if (_selectedForum != null)
            {
                //todo give error message
                _persistenceForum.Update(_selectedForum);
            }
        }
        private void DeleteForum()
        {
            if (_selectedForum != null)
            {
                //todo give error message
                _persistenceForum.Delete(_selectedForum);
                _forum.Remove(_selectedForum);
            }
        }
        private void ClearCreateForum()
        {
            ForumToBeCreated = new Forum();
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
