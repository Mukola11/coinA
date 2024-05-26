using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Models
{
    public class TopCryptoModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("current_price")]
        public decimal CurrentPrice { get; set; }

        [JsonProperty("market_cap")]
        public long MarketCap { get; set; }

        [JsonProperty("total_volume")]
        public long TotalVolume { get; set; }

    }
}
