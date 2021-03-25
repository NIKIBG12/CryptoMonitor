using CryptoMonitor.Domain.Models;
using CryptoMonitor.WPF.Commands;
using CryptoMonitor.WPF.State;
using CryptoMonitor.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoMonitor.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public static User currentUser;
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChange(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChange(nameof(Password));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        public ICommand LoginCommand { get;  }
        public ICommand ViewRegisterCommand { get; }
        public LoginViewModel(IAuthenticator authenticator, IReNavigator loginRenavigator, IReNavigator registerRenavigator)
        {
            LoginCommand = new LoginCommand(this, authenticator, loginRenavigator);
            ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
        }
    }
}
