using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using CryptoMonitor.WPF.State;
using CryptoMonitor.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace CryptoMonitor.WPF.Commands
{
    public class InvestCryptoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly InvestViewModel _investViewModel;
        private readonly IInvestService _investService;
        private readonly IAccountStore _accountStore;
        public InvestCryptoCommand(InvestViewModel investViewModel, IInvestService investService, IAccountStore accountStore)
        {
            _investViewModel = investViewModel;
            _investService = investService;
            _accountStore = accountStore;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                Account investor = await _investService.Invest(_accountStore.CurrentAccount, _investViewModel.Currency, _investViewModel.Quantity);

                _accountStore.CurrentAccount = investor;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
    }
}
