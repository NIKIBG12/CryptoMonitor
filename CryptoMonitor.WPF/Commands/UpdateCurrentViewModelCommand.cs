using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using CryptoMonitor.EntityFramework;
using CryptoMonitor.EntityFramework.Services;
using CryptoMonitor.WPF.State.Navigators;
using CryptoMonitor.WPF.ViewModels;
using CryptoMonitor.WPF.ViewModels.Factories;
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

        private readonly INavigator _navigator;
        private readonly ICryptoMonitorViewModelAbstract _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, ICryptoMonitorViewModelAbstract viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
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

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}