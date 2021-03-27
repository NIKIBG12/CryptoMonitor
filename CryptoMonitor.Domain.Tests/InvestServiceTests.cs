using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Tests
{
    [TestFixture]
    public class InvestServiceTests
    {

        private Mock<ICryptoPriceService> _cryptoPriceService;
        private Mock<IAccountService> _accountService;
        private InvestService _investService;

        [SetUp]
        public void SetUp()
        {
            _cryptoPriceService = new Mock<ICryptoPriceService>();
            _accountService = new Mock<IAccountService>();

            _investService = new InvestService(_cryptoPriceService.Object, _accountService.Object);
        }

        [Test]
        public void Invest_InvalidSymbol()
        {
            string invalidCurrency = "randomSymbol";
            _cryptoPriceService.Setup(s => s.GetPrice(invalidCurrency)).ThrowsAsync(new InvalidCurrencyException(invalidCurrency));

            InvalidCurrencyException exception = Assert.ThrowsAsync<InvalidCurrencyException>(
                () => _investService.Invest(It.IsAny<Account>(), invalidCurrency, It.IsAny<int>()));
            string actualInvalidSymbol = exception.Currency;

            Assert.AreEqual(invalidCurrency, actualInvalidSymbol);
        }

        [Test]
        public void GetPriceError()
        {
            _cryptoPriceService.Setup(s => s.GetPrice(It.IsAny<string>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(
                () => _investService.Invest(It.IsAny<Account>(), It.IsAny<string>(), It.IsAny<int>()));
        }

        [Test]
        public void AccountUpdateFail()
        {
            Account investor = CreateAccount(1000);
            _cryptoPriceService.Setup(s => s.GetPrice(It.IsAny<string>())).ReturnsAsync(100);
            _accountService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<Account>())).Throws(new Exception());

            Assert.ThrowsAsync<Exception>(() => _investService.Invest(investor, It.IsAny<string>(), 1));
        }

        [Test]
        public async Task SuccesInvest()
        {
            int transactions = 1;
            Account investor = CreateAccount(1000);
            _cryptoPriceService.Setup(s => s.GetPrice(It.IsAny<string>())).ReturnsAsync(100);

            investor = await _investService.Invest(investor, It.IsAny<string>(), 1);
            int realTransactions = investor.CryptoInvestments.Count;

            Assert.AreEqual(transactions, realTransactions);
        }

        [Test]
        public async Task SuccessInvest_BalanceChecl()
        {
            double balance = 0;
            Account investor = CreateAccount(100);
            _cryptoPriceService.Setup(s => s.GetPrice(It.IsAny<string>())).ReturnsAsync(50);

            investor = await _investService.Invest(investor, It.IsAny<string>(), 2);
            double realBalance = investor.Balance;

            Assert.AreEqual(balance, realBalance);
        }

        private Account CreateAccount(double balance)
        {
            return new Account()
            {
                Balance = balance,
                CryptoInvestments = new List<CryptoInvestment>()
            };
        }
    }
}

