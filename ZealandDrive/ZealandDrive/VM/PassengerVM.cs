using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.VM
{
    class PassengerVM
    {
        //instance fields
        #region Instancefields
        private UserVM _uvm;
        private RouteVM _rvm;
        private CarVM _cvm;
        private ForumVM _fvm;
        private SprogVM _svm;
        private MainVM _mvm;
        #endregion

        //Constructor
        #region Constructor

        public PassengerVM()
        {
            _uvm = new UserVM();
            _rvm = new RouteVM();
            _cvm = new CarVM();
            _fvm = new ForumVM();
            _svm = new SprogVM();
            _mvm = new MainVM();
        }

        #endregion

        //Properties
        #region Properties



        #endregion
        //Method

        #region Method

        

        #endregion
    }
}
