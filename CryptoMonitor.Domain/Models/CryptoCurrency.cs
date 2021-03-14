using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Models
{
    public class CryptoCurrency
    {
        public string Symbol { get; set; }

        public double Price { get; set; }
    }
}
