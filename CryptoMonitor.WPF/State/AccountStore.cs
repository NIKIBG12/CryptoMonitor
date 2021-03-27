using CryptoMonitor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.WPF.State
{
    public class AccountStore : IAccountStore
    {
        public Account CurrentAccount { get; set; }
    }
}
