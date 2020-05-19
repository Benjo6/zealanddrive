using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ZealandDrive.VM
{
    public class SprogVM : INotifyPropertyChanged
    {
        static bool m_blnInitDanish = true;

        public void InitDanishOnce()
        {
            if (m_blnInitDanish)
            {
                Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = "da-dk";

                Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
                Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
                m_blnInitDanish = false;
            }
        }
        public void ClickLanguage()
        {
            if (m_blnInitDanish)
            {
                Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = "da-dk";
                m_blnInitDanish = false;
            }
            else
            {
                Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = "en";
                m_blnInitDanish = true;
            }

            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();

        }


        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
