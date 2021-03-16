using System;
using CryptoMonitor.CryptoInfoAPI.Services;
using CryptoMonitor.Domain;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            new CryptoInfoService().GetCryptoInfo(CryptoMonitor.Domain.Models.CryptoType.BTCUSD).ContinueWith((task) =>
            {
                var index = task.Result;
            });
        }
    }
}
