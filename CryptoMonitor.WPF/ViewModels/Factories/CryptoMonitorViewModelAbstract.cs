using CryptoMonitor.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.WPF.ViewModels.Factories
{
    public class CryptoMonitorViewModelAbstract : ICryptoMonitorViewModelAbstract
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<ProfileViewModel> _createProfileViewModel;
        private readonly CreateViewModel<LoginViewModel> _CreateLoginViewModel;
public CryptoMonitorViewModelAbstract(CreateViewModel<HomeViewModel> createHomeViewModel, CreateViewModel<ProfileViewModel> createProfileViewModel, CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createProfileViewModel = createProfileViewModel;
            _CreateLoginViewModel = createLoginViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Profile:
                    return  _createProfileViewModel();
                case ViewType.Login:
                    return _CreateLoginViewModel();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
