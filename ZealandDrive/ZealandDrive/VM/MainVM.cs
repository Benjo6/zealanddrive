using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandDrive.Model;

namespace ZealandDrive.VM
{
    class MainVM
    {
        #region Instance
        
        private Commands c;
        private Rute _selectedItem;
        private Singleton _shared;
        private ObservableCollection<Rute> _rutes; 
        #endregion

        #region Constructor
        public MainVM()
        {
            c = new Commands();
            _selectedItem = _rutes[0];
            _shared = Singleton.Instance;
        }

        #endregion

        #region Properties

        public RelayCommand GoToLogin
        {
            get
            {
                return c.Login;
            }
        }

        public RelayCommand GoToOpretRute => c.OpretRute;

        public RelayCommand GoToOverview => c.GoOverviewPage;

        public RelayCommand GoBack => c.Tilbage;

        public Singleton Shared => _shared;

        public ObservableCollection<Rute> Rutes => _rutes;

        #endregion

        #region Method

        #endregion
    }
}
