using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain
{
   public class InsufficientFundsException : Exception
    {
        public double Balance { get; set; }
        public double NeededBalance { get; set; }

        public InsufficientFundsException(double balance, double neddedBalance)
        {
            Balance = balance;
            NeededBalance = neddedBalance;
        }

        public InsufficientFundsException(double balance, double neddedBalance, string message) : base(message)
        {
            Balance = balance;
            NeededBalance = neddedBalance;
        }

        public InsufficientFundsException(double balance, double neddedBalance, string message, Exception innerException) : base(message, innerException)
        {
            Balance = balance;
            NeededBalance = neddedBalance;
        }
    }
}
