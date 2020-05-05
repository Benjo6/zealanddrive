using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ZealandDrive.View;

namespace ZealandDrive.Model
{
    class Commands
    {
        #region Instance
        public RelayCommand loginPage;
        private NavigationService navigationService;
        public RelayCommand oRutePage;
        public RelayCommand overviewPage;
        public RelayCommand tilbagePage;
        #endregion

        #region Constructor
        public Commands()
        {
            navigationService = new NavigationService();
            loginPage = new RelayCommand(GotoLogin);
            oRutePage = new RelayCommand(GotoOpretRute);
            overviewPage = new RelayCommand(GotoOverview);
            tilbagePage = new RelayCommand(GoBack);
        }
        #endregion

        #region Properties

        public RelayCommand Login
        {
            get
            {
                return loginPage;
            }
        }

        public RelayCommand OpretRute => oRutePage;

        public RelayCommand GoOverviewPage => overviewPage;

        public RelayCommand Tilbage => tilbagePage;
        #endregion

        #region Method

        public void GoBack()
        {
            var frame = (Frame)Window.Current.Content;
            if (frame.CanGoBack)
                frame.GoBack();
        }

        public void GotoLogin()
        {
            {
                navigationService.navigate(typeof(View.LoginPage));
            }
        }
        public void GotoOpretRute()
        {
            {
                navigationService.navigate(typeof(View.OpretRutePage));
            }
        }
        public void GotoOverview()
        {
            {
                navigationService.navigate(typeof(View.OverviewPage));
            }
        }
        #endregion
    }
}
