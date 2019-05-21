using System.Collections.Generic;
using TradePMR.DanielSerrano.Common;
using TradePMR.DanielSerrano.Data.Models;

namespace TradePMR.DanielSerrano.Data.Interfaces
{
    public interface ITradeRepository : IRepository<Trade>
    {
        IEnumerable<Trade> Query(
            TradeQueryParameter query
        );
    }
}
