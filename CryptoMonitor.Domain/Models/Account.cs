using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Models
{
   public class Account : DomainObject
    {
        public User AccountOwner { get; set; }
    }
}
