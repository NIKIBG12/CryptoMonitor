using CryptoMonitor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Services
{
    public interface IAuthenticationService
    {
        public enum RegistrationResult
        {
            Success,
            PasswordsNotMatch,
            EmailAlreadyExists,
            UsernameAlreadyExists
        }

        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);

        Task<Account> Login(string username, string password);
    }
}
