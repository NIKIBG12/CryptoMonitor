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
        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<CryptoCurrency> CryptoCurrecies { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public CryptoDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().OwnsOne(a => a.CryptoCurrency);
            base.OnModelCreating(modelBuilder);
        }
    }
}
