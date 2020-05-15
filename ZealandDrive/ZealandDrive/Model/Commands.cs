using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ZealandDrive.Common;
using ZealandDrive.View;
using ZealandDrive.VM;


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
        public RelayCommand sRutePage;
        public RelayCommand settingPage;
        public RelayCommand opretBruger;
        private RelayCommand aOS;
        private RelayCommand gemadresse;
        private RelayCommand gemBiler;
        private RelayCommand gemteadresser;
        private RelayCommand gemteBiler;
        private RelayCommand personligeinf;
        private RelayCommand privat;
        private RelayCommand sprog;
        #endregion

        #region Constructor
        public Commands()
        {
            navigationService = new NavigationService();
            loginPage = new RelayCommand(GotoLogin);
            oRutePage = new RelayCommand(GotoOpretRute);
            overviewPage = new RelayCommand(GotoOverview);
            tilbagePage = new RelayCommand(GoBack);
            sRutePage = new RelayCommand(GotoSpecificRutePage);
            settingPage = new RelayCommand(GoSetting);
            opretBruger = new RelayCommand(GotoOpretBruger);
            aOS = new RelayCommand(GOAOS);

            gemadresse = new RelayCommand(GOGemAdresse);
            gemBiler = new RelayCommand(GOGemBil);
            gemteadresser = new RelayCommand(GOGemteAdresse);
            gemteBiler = new RelayCommand(GOGemteBil);
            personligeinf = new RelayCommand(GoPersonligeInformation);
            privat = new RelayCommand(GoPrivatlivsindstillinger);
            sprog = new RelayCommand(GoSprog);
            

        }
        #endregion

        #region Properties
        public RelayCommand GemAdresse => gemadresse;
        public RelayCommand GemteAdresse => gemteadresser;
        public RelayCommand GemBiler => gemBiler;
        public RelayCommand GemteBiler => gemteBiler;
        public RelayCommand PI => personligeinf;
        public RelayCommand Privat => privat;
        public RelayCommand Sprog => sprog;

        public RelayCommand Login
        {
            get
            {
                return loginPage;
            }
        }

        public RelayCommand Opret
        {
            get
            {
                return opretBruger;
            }
        }

        public RelayCommand GoToSpecificRutePage
        {
            get
            {
                return sRutePage;
            }
        }
        public RelayCommand AOS => aOS;

        public RelayCommand OpretRute => oRutePage;

        public RelayCommand GoOverviewPage => overviewPage;

        public RelayCommand Tilbage => tilbagePage;

        //public RelayCommand test => sRutePage;

        public RelayCommand SRutePage => GoToSpecificRutePage;

        public RelayCommand SettingPage => settingPage;

        #endregion


        #region Method

        public void GoSetting()
        {
            navigationService.navigate(typeof(View.Settings));

        }

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

        public void GotoSpecificRutePage()
        {
            {
                navigationService.navigate(typeof(View.SpecificRoutePage));
            }
        }

        public void GotoOpretBruger()
        {
            {
                navigationService.navigate(typeof(View.OpretBruger));
            }
        }
        public void GOAOS()
        {
            {
                navigationService.navigate(typeof(View.AdgangskodeogSikkerhed));
            }
        }
        public void GOGemAdresse()
        {
            {
                navigationService.navigate(typeof(View.GemRute));
            }
        }
        public void GOGemBil()
        {
            {
                navigationService.navigate(typeof(View.GemBiler));
            }
        }
        public void GOGemteBil()
        {
            {
                navigationService.navigate(typeof(View.GemteBiler));
            }
        }
        public void GOGemteAdresse()
        {
            {
                navigationService.navigate(typeof(View.GemteAdresser));
            }
        }
        public void GoPersonligeInformation()
        {
            {
                navigationService.navigate(typeof(View.PersonligeInformation));
            }
        }
        public void GoPrivatlivsindstillinger()
        {
            {
                navigationService.navigate(typeof(View.Privatlivsindstillinger));
            }
        }
        public void GoSprog()
        {
            {
                navigationService.navigate(typeof(View.Sprog));
            }
        }
        #endregion
    }
}
