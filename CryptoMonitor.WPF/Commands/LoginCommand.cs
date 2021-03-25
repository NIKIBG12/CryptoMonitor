using CryptoMonitor.WPF.State;
using CryptoMonitor.WPF.State.Navigators;
using CryptoMonitor.WPF.ViewModels;
using CryptoMonitor.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace CryptoMonitor.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IReNavigator _renavigator;
        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, IReNavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            bool success = await _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);
            if (success)
            {
                _renavigator.Renavigate();
            }
        }
    }
}
