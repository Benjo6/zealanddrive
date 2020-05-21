using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using ZealandDrive.Common;
using ZealandDrive.Model;

namespace ZealandDrive.VM
{
    public class SprogVM
    {
        private PageCommand p;

        public SprogVM()
        {
            p = new PageCommand();
        }


        public ICommand Dansk => p.SettingPage;
        public ICommand Engelsk => p.SettingPageEN;
        

        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
