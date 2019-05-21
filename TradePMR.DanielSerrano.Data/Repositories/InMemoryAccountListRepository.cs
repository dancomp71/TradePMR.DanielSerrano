using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TradePMR.DanielSerrano.Common;
using TradePMR.DanielSerrano.Data.Interfaces;
using TradePMR.DanielSerrano.Data.Models;

namespace TradePMR.DanielSerrano.Data.Repositories
{
    public class InMemoryAccountListRepository : IAccountRepository
    {
        private List<Account> accounts = new List<Account>(Seeder.Accounts());

        public IEnumerable<Account> GetAll()
        {
            return this.accounts;
        }

        public Account GetById(int id)
        {
            return this.accounts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Account> Query(AccountQueryParameter p)
        {
            var result = this.accounts.Where(x =>
                string.IsNullOrEmpty(p.Name) ||
                x.Name.ToLowerInvariant().StartsWith(p.Name.ToLowerInvariant()));
            if (p.Skip != null)
                result = result.Skip(p.Skip.Value);
            if (p.Take != null)
                result = result.Take(p.Take.Value);
            return result.AsEnumerable();
        }

        public Account Add(Account account)
        {
            var maxId = accounts.Max(x => x.Id) + 1;
            account.Id = maxId;
            account.DateCreated = account.DateUpdated = DateTime.Now;
            this.accounts.Add(account);
            return account;
        }

        public Account Update(Account account)
        {
            var acct = this.accounts.FirstOrDefault(x => x.Id == account.Id);
            acct.Id = account.Id;
            acct.Name = account.Name;
            acct.DateUpdated = DateTime.Now;
            acct.DateCreated = account.DateCreated;
            return acct;
        }

        public Account Delete(int id)
        {
            var account = this.accounts.FirstOrDefault(x => x.Id == id);
            if( account != null)
            {
                this.accounts.Remove(account);
                return account;
            }
            return null;
        }

        public IEnumerable<ValidationResult> Validate(Account entity)
        {
            var result = new List<ValidationResult>();
            return result;
        }
    }
}
