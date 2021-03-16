using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public CryptoInfoViewModel CryptoInfoViewModel { get; set; }
        public HomeViewModel(CryptoInfoViewModel cryptoInfoViewModel)
        {
            CryptoInfoViewModel = cryptoInfoViewModel;
        }

    }
}
