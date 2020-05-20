using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.VoiceCommands;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ZealandDrive.Common;

namespace ZealandDrive.Model
{
    class PageCommand
    {
        #region Instance
        private NavigationService navigationService;
        //Sideskift
        public RelayCommand _userTest;
        public RelayCommand loginPage;
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
        private RelayCommand fo;
        private RelayCommand foo;


        #endregion

        #region Constructor
        public PageCommand()
        {
            //Sideskift
            _userTest = new RelayCommand(GoToUserTest);
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
            fo = new RelayCommand(GoFO);
            foo = new RelayCommand(GoFOO);

        }
        #endregion

        #region Properties

        //Sideskift
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

        public RelayCommand GoOverviewPage
        {
            get
            {
                return overviewPage;
            }
        }

        public RelayCommand Tilbage => tilbagePage;

        //public RelayCommand test => sRutePage;

        public RelayCommand SRutePage => GoToSpecificRutePage;

        public RelayCommand SettingPage => settingPage;
        public RelayCommand FOPage => fo;
        public RelayCommand FOOPage => foo;
        public RelayCommand UserTest => _userTest;
        #endregion


        #region Method

        //Page Switch
        public void GoToUserTest()
        {
            navigationService.navigate(typeof(View.UserTest));
        }
        public void GoSetting()
        {
            navigationService.navigate(typeof(View.Settings));

        }
        public void GoFO()
        {
            navigationService.navigate(typeof(View.ForumOverview));

        }
        public void GoFOO()
        {
            navigationService.navigate(typeof(View.OpretForum));

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
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
