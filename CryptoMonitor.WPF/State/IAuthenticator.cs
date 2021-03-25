using CryptoMonitor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CryptoMonitor.Domain.Services.IAuthenticationService;

namespace CryptoMonitor.WPF.State
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }

        bool IsLoggedIn { get; }
        Task<RegistrationResult> Register(string email, string username, string password, string  confirmPassowrd);
        Task<bool> Login(string username, string password);

        void Logout();
    }
}
