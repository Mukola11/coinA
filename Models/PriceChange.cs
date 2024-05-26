using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Models
{
    public class PriceChange
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
