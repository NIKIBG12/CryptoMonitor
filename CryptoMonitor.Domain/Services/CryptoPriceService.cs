using CryptoMonitor.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Services
{
    public class CryptoPriceService : ICryptoPriceService
    {
        public async Task<double> GetPrice(string currency)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://api.cryptonator.com/api/ticker/" + currency + "-usd");
                string jsonResponse = await response.Content.ReadAsStringAsync();

                CryptoInfo cryptoInfo = JsonConvert.DeserializeObject<CryptoInfo>(jsonResponse);
                client.Dispose();
                return cryptoInfo.Ticker.Price;
            }
        }
    }
}
