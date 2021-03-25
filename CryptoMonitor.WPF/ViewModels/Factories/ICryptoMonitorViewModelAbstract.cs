using CryptoMonitor.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.WPF.ViewModels.Factories
{
    public interface ICryptoMonitorViewModelAbstract
    {
        ViewModelBase CreateViewModel(ViewType viewType); 
    }
}
