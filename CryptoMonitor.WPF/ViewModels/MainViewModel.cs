using CryptoMonitor.WPF.Commands;
using CryptoMonitor.WPF.State;
using CryptoMonitor.WPF.State.Navigators;
using CryptoMonitor.WPF.ViewModels.Factories;
using System.Windows.Input;

namespace CryptoMonitor.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ICryptoMonitorViewModelAbstract _viewModelFactory;
        public INavigator Navigator { get; set; }

        public IAuthenticator Authenticator { get; set; }

        public ICommand UpdateCurrentViewModelCommand { get;  }
        public MainViewModel(INavigator navigator, ICryptoMonitorViewModelAbstract viewModelFactory, IAuthenticator authenticator)
        {
            Authenticator = authenticator;
            Navigator = navigator;
            _viewModelFactory = viewModelFactory;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory );
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }
    }
}
