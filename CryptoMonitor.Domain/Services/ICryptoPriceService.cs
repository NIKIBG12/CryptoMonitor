using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Services
{
    public interface ICryptoPriceService
    {
        Task<double> GetPrice(string currency);
    }
}
