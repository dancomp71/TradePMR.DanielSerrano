using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradePMR.DanielSerrano.Common
{
    public class Account : BaseDateClass
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Trade> Trades { get; set; }
    }
}
