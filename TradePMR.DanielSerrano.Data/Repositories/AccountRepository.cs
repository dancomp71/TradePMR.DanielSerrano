using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TradePMR.DanielSerrano.Common;
using TradePMR.DanielSerrano.Data.Interfaces;
using TradePMR.DanielSerrano.Data.Models;

namespace TradePMR.DanielSerrano.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TradePMRDbContext context;

        public AccountRepository(TradePMRDbContext context)
        {
            this.context = context;
        }

        public Account Add(Account account)
        {
            account.DateCreated = account.DateUpdated = DateTime.Now;
            context.Accounts.Add(account);
            // context.Entry<Account>(account).State = EntityState.Detached;
            context.SaveChanges();
            return account;
        }

        public Account Delete(int id)
        {
            var account = context.Accounts.FirstOrDefault(x => x.Id == id);
            if (account == null)
                return null;
            context.Remove(account);
            context.SaveChanges();
            return account;
        }

        public IEnumerable<Account> GetAll()
        {
            return context.Accounts;
        }

        public Account GetById(int id)
        {
            return context.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Account> Query(AccountQueryParameter p)
        {
            var result = context.Accounts.Where(x =>
                string.IsNullOrEmpty(p.Name) ||
                x.Name.ToLowerInvariant().StartsWith(p.Name.ToLowerInvariant()));
            if (p.Skip != null)
                result = result.Skip(p.Skip.Value);
            if (p.Take != null)
                result = result.Take(p.Take.Value);
            return result.AsEnumerable();
        }

        public Account Update(Account account)
        {
            var acct = context.Accounts.FirstOrDefault(x => x.Id == account.Id);
            acct.Id = account.Id;
            acct.Name = account.Name;
            acct.DateUpdated = DateTime.Now;
            context.Entry(acct).State = EntityState.Modified;
            context.SaveChanges();
            return acct;
        }

        public IEnumerable<ValidationResult> Validate(Account account)
        {
            var result = new List<ValidationResult>();

            if (string.IsNullOrEmpty(account.Name))
                result.Add(new ValidationResult("Name is requied"));

            return result;
        }
    }
}
