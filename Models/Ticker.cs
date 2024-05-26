using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Models
{
    public class Ticker
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("market")]
        public Market Market { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }

        [JsonProperty("trade_url")]
        public string MarketUrl { get; set; }
    }

    public class Market
    {
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
