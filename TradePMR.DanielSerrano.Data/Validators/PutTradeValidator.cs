using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TradePMR.DanielSerrano.Data.Models;

namespace TradePMR.DanielSerrano.Data.Validators
{
    public class PutTradeValidator
    {
        private readonly TradePMRDbContext context;
        private readonly PutTradeParameter trade;

        public PutTradeValidator(TradePMRDbContext context, PutTradeParameter trade)
        {
            this.context = context;
            this.trade = trade;
        }

        public IEnumerable<ValidationResult> Validate()
        {
            var result = new List<ValidationResult>();

            if (trade.AccountId <= 0)
            {
                result.Add(new ValidationResult("Invalid Trade AccountId", new[] { "accountId" }));
            }

            var t = context.Trades.FirstOrDefault(x => x.Id == trade.Id);
            if(t == null)
            {
                result.Add(new ValidationResult("Trade cannot be found", new[] { "id" }));
            }

            if(t.AccountId != trade.AccountId)
            {
                result.Add(new ValidationResult("AccountId cannot be modified", new[] { "accountId" }));
            }

            if (string.IsNullOrEmpty(trade.Symbol))
            {
                result.Add(new ValidationResult("Invalid Trade Symbol", new[] { "symbol" }));
            }

            return result;
        }
    }
}
