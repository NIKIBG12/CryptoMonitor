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
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewModelCommand { get;  }
        public MainViewModel(INavigator navigator, ICryptoMonitorViewModelAbstract viewModelFactory, IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _navigator.StateChanged += _navigator_StateChanged;
            _authenticator.StateChanged += _authenticator_StateChanged;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory );
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

        private void _authenticator_StateChanged()
        {
            OnPropertyChange(nameof(IsLoggedIn));
        }

        private void _navigator_StateChanged()
        {
            OnPropertyChange(nameof(CurrentViewModel));
        }
    }
}
