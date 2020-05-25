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
        private RelayCommand GPO;

        //Engelsk
        public RelayCommand _userTestEN;
        public RelayCommand loginPageEN;
        public RelayCommand oRutePageEN;
        public RelayCommand overviewPageEN;
        public RelayCommand tilbagePageEN;
        public RelayCommand sRutePageEN;
        public RelayCommand settingPageEN;
        public RelayCommand opretBrugerEN;
        private RelayCommand aOSEN;
        private RelayCommand gemadresseEN;
        private RelayCommand gemBilerEN;
        private RelayCommand gemteadresserEN;
        private RelayCommand gemteBilerEN;
        private RelayCommand personligeinfEN;
        private RelayCommand privatEN;
        private RelayCommand sprogEN;
        private RelayCommand foEN;
        private RelayCommand fooEN;

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
            GPO = new RelayCommand(GoPasOversigt);
                    

        //Engelsk

        loginPageEN = new RelayCommand(GotoLoginEN);
            oRutePageEN = new RelayCommand(GotoOpretRuteEN);
            overviewPageEN = new RelayCommand(GotoOverviewEn);
            sRutePageEN = new RelayCommand(GotoSpecificRutePageEn);
            settingPageEN = new RelayCommand(GoSettingEN);
            opretBrugerEN = new RelayCommand(GotoOpretBrugerEN);
            aOSEN = new RelayCommand(GOAOSEN);
            gemadresseEN = new RelayCommand(GOGemAdresseEN);
            gemBilerEN = new RelayCommand(GOGemBilEn);
            gemteadresserEN = new RelayCommand(GOGemteAdresseEN);
            gemteBilerEN = new RelayCommand(GOGemteBilEn);
            personligeinfEN = new RelayCommand(GoPersonligeInformationEN);
            privatEN = new RelayCommand(GoPrivatlivsindstillingerEN);
            sprogEN = new RelayCommand(GoSprogEN);
            foEN = new RelayCommand(GoFOEN);
            fooEN = new RelayCommand(GoFOOEN);

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
            set => sRutePage = value;
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
        public RelayCommand GOPasO => GPO;
        //Engelsk
        public RelayCommand GemAdresseEN => gemadresseEN;
        public RelayCommand GemteAdresseEN => gemteadresserEN;
        public RelayCommand GemBilerEN => gemBilerEN;
        public RelayCommand GemteBilerEN => gemteBilerEN;
        public RelayCommand PIEN => personligeinfEN;
        public RelayCommand PrivatEN => privatEN;
        public RelayCommand SprogEN => sprogEN;

        public RelayCommand LoginEN
        {
            get
            {
                return loginPage;
            }
        }

        public RelayCommand OpretEN
        {
            get
            {
                return opretBruger;
            }
        }

        public RelayCommand GoToSpecificRutePageEN
        {
            get
            {
                return sRutePage;
            }
        }
        public RelayCommand AOSEN => aOSEN;

        public RelayCommand OpretRuteEN => oRutePageEN;

        public RelayCommand GoOverviewPageEN
        {
            get
            {
                return overviewPageEN;
            }
        }

        public RelayCommand TilbageEN => tilbagePageEN;

        //public RelayCommand test => sRutePage;

        public RelayCommand SRutePageEN => GoToSpecificRutePageEN;

        public RelayCommand SettingPageEN => settingPageEN;
        public RelayCommand FOPageEN => foEN;
        public RelayCommand FOOPageEN => fooEN;

        #endregion


        #region Method

        //Page Switch
        public void GoToUserTest()
        {
            navigationService.navigate(typeof(View_Dk.AdminPage));
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

        public void GoPasOversigt()
        {
            {
                navigationService.navigate(typeof(View_Dk.PassagerOversigt));
            }
        }
        //Engelsk

        public void GoSettingEN()
        {
            navigationService.navigate(typeof(View_En.Settings));

        }
        public void GoFOEN()
        {
            navigationService.navigate(typeof(View_En.ForumOverview));

        }
        public void GoFOOEN()
        {
            navigationService.navigate(typeof(View_En.CreateForum));

        }


        public void GotoLoginEN()
        {
            {
                navigationService.navigate(typeof(View_En.LoginPage));
            }
        }
        public void GotoOpretRuteEN()
        {
            {
                navigationService.navigate(typeof(View_En.CreateRoutesPage));
            }
        }
        public void GotoOverviewEn()
        {
            {
                navigationService.navigate(typeof(View_En.OverviewPage));
            }
        }

        public void GotoSpecificRutePageEn()
        {
            {
                navigationService.navigate(typeof(View_En.SpecficRoutePage));
            }
        }

        public void GotoOpretBrugerEN()
        {
            {
                navigationService.navigate(typeof(View_En.CreateUser));
            }
        }
        public void GOAOSEN()
        {
            {
                navigationService.navigate(typeof(View_En.PasswordSecurity));
            }
        }
        public void GOGemAdresseEN()
        {
            {
                navigationService.navigate(typeof(View_En.SaveAddresse));
            }
        }
        public void GOGemBilEn()
        {
            {
                navigationService.navigate(typeof(View_En.SaveCars));
            }
        }
        public void GOGemteBilEn()
        {
            {
                navigationService.navigate(typeof(View_En.SavedCars));
            }
        }
        public void GOGemteAdresseEN()
        {
            {
                navigationService.navigate(typeof(View_En.SavedAddresses));
            }
        }
        public void GoPersonligeInformationEN()
        {
            {
                navigationService.navigate(typeof(View_En.PersonalInformation));
            }
        }
        public void GoPrivatlivsindstillingerEN()
        {
            {
                navigationService.navigate(typeof(View_En.PrivacySettings));
            }
        }
        public void GoSprogEN()
        {
            {
                navigationService.navigate(typeof(View_En.Language));
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
