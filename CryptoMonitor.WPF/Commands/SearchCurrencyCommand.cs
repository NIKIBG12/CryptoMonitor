using CryptoMonitor.Domain.Services;
using CryptoMonitor.WPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace CryptoMonitor.WPF.Commands
{
    public class SearchCurrencyCommand : ICommand
    {
        private readonly InvestViewModel _investViewModel;
        private readonly ICryptoPriceService _cryptoPriceService;

        public event EventHandler CanExecuteChanged;
        public SearchCurrencyCommand(InvestViewModel investViewModel, ICryptoPriceService cryptoPriceService)
        {
            _investViewModel = investViewModel;
            _cryptoPriceService = cryptoPriceService;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                double price = await _cryptoPriceService.GetPrice(_investViewModel.Currency);
                _investViewModel.Price = price;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
    }
}
