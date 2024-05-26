using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Models
{
    public class MarketData
    {
        [JsonProperty("current_price")]
        public Dictionary<string, decimal> CurrentPrice { get; set; }

        [JsonProperty("total_volume")]
        public Dictionary<string, decimal> TotalVolume { get; set; }
    }
}
