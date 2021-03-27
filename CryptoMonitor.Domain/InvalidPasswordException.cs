using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain
{
    public class InvalidPasswordException : Exception
    {

        public string Username { get; set; }
        public string Paswword { get; set; }
        public InvalidPasswordException(string username, string paswword)
        {
            Username = username;
            Paswword = paswword;
        }

        public InvalidPasswordException(string message, string username, string paswword) : base(message)
        {
            Username = username;
            Paswword = paswword;
        }

        public InvalidPasswordException(string message, Exception innerException, string username, string paswword) : base(message, innerException)
        {
            Username = username;
            Paswword = paswword;
        }
    }
}
