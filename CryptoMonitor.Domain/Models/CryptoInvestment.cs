using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Models
{
    public class CryptoInvestment : DomainObject
    {
        public Account Account { get; set; }
        public bool IsPurchase { get; set; }
        public CryptoCurrencyInvest CryptoCurrencyInvest { get; set; }
        public int Quantity { get; set; }
        public DateTime DateInvested { get; set; }
    }
}
