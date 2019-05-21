using System;
using TradePMR.DanielSerrano.Common;

namespace TradePMR.DanielSerrano.Data.Models
{
    public class TradeQueryParameter : PagingQueryParameter
    {
        public DateTime? DateCreated { get; set; }

        public string Symbol { get; set; }

        public TradeActions? Action { get; set; }

        public int? AccountId { get; set; }
    }
}
