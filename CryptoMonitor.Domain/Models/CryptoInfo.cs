using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Models
{
    public enum CryptoType
    {
        BTC,
        ETH,
        BNB,
        USDT,
        ADA,
        DOT,
        XRP,
        UNI,
        LTC,
        LINK
    }


    public partial class CryptoInfo
    {
        [JsonProperty("ticker")]
        public Ticker Ticker { get; set; }

        public CryptoType Type { get; set; }

        public CryptoInfo(CryptoType type, Ticker ticker)
        {
            this.Type = type;
            this.Ticker = ticker;
        }
    }

    public partial class Ticker
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("change")]
        public double Change { get; set; }

        public Ticker(string ticker, double price, double change)
        {
            this.Base = ticker;
            this.Price = price;
            this.Change = change;
        }
    }
}
