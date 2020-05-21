using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.System;
using ClassLibrary;
using ZealandDrive.Persistens;

namespace ZealandDrive.Common
{
    class SharedKnowledge : INotifyPropertyChanged
    {
        private string _userNow;
		private string _passNow;

        public SharedKnowledge(string userNow)
        {
            _userNow = userNow;
            UserCurrent = new Users();
        }

        public List<User> Users
		{
			get => Users;
            set => Users = value;
        }
		public string PassNow
		{
			get => _passNow;
            set
			{
				_passNow = value;
				OnPropertyChanged();
			}
		}
		public Users UserCurrent { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged
		([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
