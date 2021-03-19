using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using CryptoMonitor.EntityFramework;
using CryptoMonitor.EntityFramework.Services;
using CryptoMonitor.WPF.State.Navigators;
using CryptoMonitor.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static CryptoMonitor.WPF.State.Navigators.INavigator;

namespace CryptoMonitor.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private CryptoDbContextFactory dbContextFactory;
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
            dbContextFactory = new CryptoDbContextFactory();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel(CryptoInfoViewModel.LoadCryptoInfoViewModel(new CryptoInfoService(), new GenerecDataService<CryptoCurrency>(dbContextFactory)));
                        break;
                    case ViewType.Profile:
                        _navigator.CurrentViewModel = new ProfileViewModel();
                        break;
                }
            }
        }
    }
}