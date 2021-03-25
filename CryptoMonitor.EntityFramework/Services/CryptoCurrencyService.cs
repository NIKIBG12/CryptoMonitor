using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.EntityFramework.Services
{
    public class CryptoCurrencyService : ICryptoCurrencyService
    {

        private readonly CryptoDbContextFactory _contextFactory;

        public CryptoCurrencyService(CryptoDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<CryptoCurrency> Create(CryptoCurrency entity)
        {
            using (CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<CryptoCurrency> created = await context.Set<CryptoCurrency>().AddAsync(entity);
                await context.SaveChangesAsync();
                return created.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                CryptoCurrency entity = await context.Set<CryptoCurrency>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set< CryptoCurrency>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<CryptoCurrency> Get(int id)
        {
            using(CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                CryptoCurrency entity = await context.Set<CryptoCurrency>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<User> GetByUserId(int user)
        {
            using (CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                User entity = await context.Users
                    .Include(a => a.Id)
                    .FirstOrDefaultAsync((e) => e.Id == user);
                return entity;
            }
        }

        public async Task<IEnumerable<CryptoCurrency>> GetAll()
        {
            using (CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<CryptoCurrency> entities = await context.Set<CryptoCurrency>().ToListAsync();
                return entities;
            }
        }
        public async Task<CryptoCurrency> Update(int id, CryptoCurrency entity)
        {
            using (CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<CryptoCurrency>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
