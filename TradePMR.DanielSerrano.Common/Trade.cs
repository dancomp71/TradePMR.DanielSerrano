using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TradePMR.DanielSerrano.Common
{
    public class Trade : BaseDateClass
    {
        public int Id { get; set; }

        [Required]
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

        [JsonIgnore]
        public Account Account { get; set; }
    }
}
