using CryptoMonitor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Services
{
    public interface IInvestService
    {
        Task<Account> Invest(Account investor, string currency, int quantity);
    }
}
