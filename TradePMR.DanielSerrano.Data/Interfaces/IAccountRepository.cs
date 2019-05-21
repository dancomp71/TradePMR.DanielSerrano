using System.Collections.Generic;
using TradePMR.DanielSerrano.Common;
using TradePMR.DanielSerrano.Data.Models;

namespace TradePMR.DanielSerrano.Data.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        IEnumerable<Account> Query(AccountQueryParameter p);
    }
}
