using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly CryptoDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(CryptoDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {
            using (CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts.Include(a => a.AccountOwner)
                    .Include(a => a.CryptoInvestments)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts
                    .Include(a => a.AccountOwner)
                    .Include(a => a.CryptoInvestments)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Account> GetByEmail(string email)
        {
            using (CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountOwner)
                    .Include(a => a.CryptoInvestments)
                    .FirstOrDefaultAsync(a => a.AccountOwner.Email == email);
            }
        }

        public async Task<Account> GetByUsername(string username)
        {
            using (CryptoDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountOwner)
                    .Include(a => a.CryptoInvestments)
                    .FirstOrDefaultAsync(a => a.AccountOwner.Username == username);
            }
        }
        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

    }
}
