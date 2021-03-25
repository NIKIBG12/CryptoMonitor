using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Models
{
    public class CryptoCurrency : DomainObject
    {
        public string Ticker { get; set; }

        public double CurrentPrice { get; set; }

        public User User { get; set; }
    }
}
