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
                options.UseMySQL("server=eu01-sql.pebblehost.com;database=customer_122878_cryptoc;user=customer_122878_cryptoc;password=h2#5Z!1fAnVvA8~U2T1A");
                return new CryptoDbContext(options.Options);
            }
    }
}
