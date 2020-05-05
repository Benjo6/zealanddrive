﻿using System;
using System.Collections.Generic;
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

        #endregion

        #region Constructor
        public MainVM()
        {
            c = new Commands();
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

        #endregion

        #region Method

        #endregion
    }
}
