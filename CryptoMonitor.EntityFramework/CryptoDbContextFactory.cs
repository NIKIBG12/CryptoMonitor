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
<<<<<<< HEAD
                options.UseMySQL("connection details..);
=======
                options.UseMySQL("server=eu01-sql.pebblehost.com;database=.......;user=......._cryptoc;password=.......");
>>>>>>> e705bd47244053747df7b2daf62ea9c6d4a2b518
                return new CryptoDbContext(options.Options);
            }
    }
}
