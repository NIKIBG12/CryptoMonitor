using CryptoMonitor.WPF.ViewModels;
using CryptoMonitor.WPF.ViewModels.Factories;

namespace CryptoMonitor.WPF.State.Navigators
{
    public class ViewModelRenavigator<T> : IReNavigator where T : ViewModelBase
    {
        private INavigator _navigator;
        private readonly CreateViewModel<T> _createViewModel;

        public ViewModelRenavigator(INavigator navigator, CreateViewModel<T> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public void Renavigate()
        {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}
