using CryptoMonitor.WPF.Commands;
using CryptoMonitor.WPF.Models;
using CryptoMonitor.WPF.ViewModels;
using CryptoMonitor.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoMonitor.WPF.State.Navigators
{
    public class Navigator : INavigator
    { 
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        { 
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }
        public event Action StateChanged;
    }
}
