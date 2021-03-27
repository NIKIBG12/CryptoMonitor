using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain
{
    public class MissingUserException : Exception
    {

        public string Username { get; set; }
        public MissingUserException(string username)
        {
            Username = username;
        }

        public MissingUserException(string message, string username) : base(message)
        {
            Username = username;
        }

        public MissingUserException(string message, Exception innerException, string username) : base(message, innerException)
        {
            Username = username;
        }

    }
}
