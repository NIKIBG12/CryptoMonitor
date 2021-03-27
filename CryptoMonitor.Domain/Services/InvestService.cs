using CryptoMonitor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Services
{
    public class InvestService : IInvestService
    {
        private readonly ICryptoPriceService _cryptoPriceService;
        private readonly IAccountService _accountService;
        public InvestService(ICryptoPriceService cryptoPriceService, IAccountService accountService)
        {
            _cryptoPriceService = cryptoPriceService;
            _accountService = accountService;
        }
        public async Task<Account> Invest(Account investor, string currency, int quantity)
        {
            double price = await _cryptoPriceService.GetPrice(currency);

            if (price * quantity > investor.Balance)
            {
                throw new Exception("Insufficient Funds!");
            };

            CryptoInvestment cryptoInvestment = new CryptoInvestment()
            {
                Account = investor,
                CryptoCurrencyInvest = new CryptoCurrencyInvest()
                {
                    Price = price,
                    Ticker = currency,
                },
                DateInvested = DateTime.Now,
                Quantity = quantity,
                IsPurchase = true
            };
            investor.CryptoInvestments.Add(cryptoInvestment);
            investor.Balance -= price * quantity;
            await _accountService.Update(investor.Id, investor);
            return investor;
        }
    }
}
