using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Models
{
    public class User : DomainObject
    {
        public string username { get; set; }

        public int Email { get; set; }

        public string Password { get; set; }

        public DateTime DateJoined { get; set; }
    }
}
