using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Services
{
    public class CryptoInfoService : ICryptoInfoService
    {
        public async Task<CryptoInfo> GetCryptoInfo(CryptoType cryptoType)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://api.cryptonator.com/api/ticker/" + GetUriSuffix(cryptoType) + "-usd");
                string jsonResponse = await response.Content.ReadAsStringAsync();

                CryptoInfo cryptoInfo = JsonConvert.DeserializeObject<CryptoInfo>(jsonResponse);
                cryptoInfo.Type = cryptoType;
                return cryptoInfo;
            }

        }
        private string GetUriSuffix(CryptoType cryptoType)
        {
            switch (cryptoType)
            {
                case CryptoType.BTC:
                    return "BTC";
                case CryptoType.ETH:
                    return "ETH";
                case CryptoType.BNB:
                    return "BNB";
                case CryptoType.USDT:
                    return "USDT";
                case CryptoType.ADA:
                    return "ADA";
                case CryptoType.DOT:
                    return "DOT";
                case CryptoType.XRP:
                    return "XRP";
                case CryptoType.UNI:
                    return "UNI";
                case CryptoType.LTC:
                    return "LTC";
                case CryptoType.LINK:
                    return "LINK";
                default:
                    return "BTC";
            }
        }
    }
}
