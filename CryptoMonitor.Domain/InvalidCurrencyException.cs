using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain
{
    public class InvalidCurrencyException : Exception
    {
        public string Currency { get; set; }

        public InvalidCurrencyException(string currency)
        {
            Currency = currency;
        }

        public InvalidCurrencyException(string currency, string message) : base(message)
        {
            Currency = currency;
        }

        public InvalidCurrencyException(string currency, string message, Exception innerException) : base(message, innerException)
        {
            Currency = currency;
        }
    }
}
