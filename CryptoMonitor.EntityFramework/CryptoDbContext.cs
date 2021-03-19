using CryptoMonitor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.EntityFramework
{
    public class CryptoDbContext : DbContext
    {
        public DbSet<LowestPrice> LowestPrices { get; set; }

        public DbSet<HighestPrice> HighestPrices { get; set; }

        public DbSet<CryptoCurrency> CryptoCurrecies { get; set; }

        public CryptoDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CryptoCurrency>().HasData(
            new CryptoCurrency { Id = 1, Ticker = "BTC", CurrentPrice = 0.00 },
            new CryptoCurrency { Id = 2, Ticker = "ETH", CurrentPrice = 0.00 },
            new CryptoCurrency { Id = 3, Ticker = "BNB", CurrentPrice = 0.00 },
            new CryptoCurrency { Id = 4, Ticker = "USDT", CurrentPrice = 0.00 },
            new CryptoCurrency { Id = 5, Ticker = "ADA", CurrentPrice = 0.00 },
            new CryptoCurrency { Id = 6, Ticker = "DOT", CurrentPrice = 0.00 },
            new CryptoCurrency { Id = 7, Ticker = "XRP", CurrentPrice = 0.00 },
            new CryptoCurrency { Id = 8, Ticker = "UNI", CurrentPrice = 0.00 },
            new CryptoCurrency { Id = 9, Ticker = "LTC", CurrentPrice = 0.00 },
            new CryptoCurrency { Id = 10, Ticker = "LINK", CurrentPrice = 0.00 });

            modelBuilder.Entity<HighestPrice>().HasNoKey();
            modelBuilder.Entity<LowestPrice>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}
