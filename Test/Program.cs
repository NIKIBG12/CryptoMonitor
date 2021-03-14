using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using CryptoMonitor.EntityFramework;
using CryptoMonitor.EntityFramework.Services;
using System;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService = new GenerecDataService<User>(new CryptoDbContextFactory());
            Console.WriteLine(userService.Update(1, new User() {username = "Pesho" }).Result);
            Console.WriteLine(userService.Delete(1).Result);
        }
    }
}
