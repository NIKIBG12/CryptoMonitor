using CryptoMonitor.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Services
{
    public class CryptoPriceService : ICryptoPriceService
    {
        public async Task<string> GetPrice(string symbol)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://api.cryptonator.com/api/ticker/" + symbol + "-usd");
                string jsonResponse = await response.Content.ReadAsStringAsync();

                CryptoInfo cryptoInfo = JsonConvert.DeserializeObject<CryptoInfo>(jsonResponse);
                return cryptoInfo.Ticker.Price;
            }
        }
    }
}
