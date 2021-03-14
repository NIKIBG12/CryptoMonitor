using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Models
{
    public class Transaction : DomainObject
    {

        public Account Account { get; set; }

        public bool IsPurchase { get; set; }

        public CryptoCurrency CryptoCurrency { get; set; }

        public DateTime DateProcessed { get; set; }
    }
}
