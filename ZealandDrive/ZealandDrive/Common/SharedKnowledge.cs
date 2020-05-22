using System.ComponentModel;
using System.Runtime.CompilerServices;
using ClassLibrary;

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
