using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.EntityFramework
{
    public class CryptoDbContextFactory : IDesignTimeDbContextFactory<CryptoDbContext>
    {
        public CryptoDbContext CreateDbContext(string[] args = null)
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder<CryptoDbContext>();
            options.UseMySQL("...............");
            return new CryptoDbContext(options.Options);
        }
    }
}
