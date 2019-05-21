using System.ComponentModel.DataAnnotations;
using TradePMR.DanielSerrano.Common;

namespace TradePMR.DanielSerrano.Data.Models
{
    public class PutTradeParameter
    {
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int AccountId { get; set; }

        [StringLength(4)]
        [Required]
        public string Symbol { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [EnumDataType(typeof(TradeActions))]
        public TradeActions Action { get; set; }

        public static implicit operator Trade(PutTradeParameter t)
        {
            var trade = new Trade()
            {
                AccountId = t.AccountId,
                Id = t.Id,
                Quantity = t.Quantity,
                Symbol = t.Symbol
            };
            return trade;
        }

        public static implicit operator PutTradeParameter(Trade t)
        {
            var trade = new PutTradeParameter()
            {
                AccountId = t.AccountId,
                Id = t.Id,
                Quantity = t.Quantity,
                Symbol = t.Symbol
            };
            return trade;
        }
    }
}
