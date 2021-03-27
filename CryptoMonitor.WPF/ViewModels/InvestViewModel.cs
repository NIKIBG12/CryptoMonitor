using CryptoMonitor.Domain.Services;
using CryptoMonitor.WPF.Commands;
using CryptoMonitor.WPF.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoMonitor.WPF.ViewModels
{
    public class InvestViewModel : ViewModelBase
    {
        private string _currency;
        public string Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
                OnPropertyChange(nameof(Currency));
            }
        }

        private double _price;
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChange(nameof(Price));
            }
        }

        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChange(nameof(Quantity));
                OnPropertyChange(nameof(Total));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }
        public MessageViewModel StatusMessageViewModel { get; }
        public double Total
        {
            get
            {
                return Quantity * Price;
            }
        }

        public string ErrorMessage 
            {
            set => ErrorMessageViewModel.Message = value;
            }

        public string StatusMessage
        {
            set => StatusMessageViewModel.Message = value;
        }
        public ICommand SearchCurrencyCommand { get; set; }
        public ICommand InvestCryptoCommand { get; set; }
        public InvestViewModel(ICryptoPriceService cryptoPriceService, IInvestService investService, IAccountStore accountStore)
        {
            ErrorMessageViewModel = new MessageViewModel();
            StatusMessageViewModel = new MessageViewModel();
            SearchCurrencyCommand = new SearchCurrencyCommand(this, cryptoPriceService);
            InvestCryptoCommand = new InvestCryptoCommand(this, investService, accountStore);
        }
    }
}
