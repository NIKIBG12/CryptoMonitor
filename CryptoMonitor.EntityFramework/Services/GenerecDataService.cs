using CryptoMonitor.Domain;
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
    public class GenerecDataService<T> : IDataService<T> where T : DomainObject
    {

        private readonly CryptoDbContextFactory _contextFactory;

        public GenerecDataService(CryptoDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> created = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return created.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using(CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        } 
        public async Task<T> Update(int id, T entity)
        {
                using (CryptoDbContext context = _contextFactory.CreateDbContext())
                {
                    entity.Id = id;
                    context.Set<T>().Update(entity);
                    await context.SaveChangesAsync();
                    return entity;
                }
        }
    }
}
