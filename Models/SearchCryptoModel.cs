using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Models
{
    public class SearchResponse
    {
        [JsonProperty("coins")]
        public List<SearchCryptoModel> Coins { get; set; }
    }

    public class SearchCryptoModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("large")]
        public string Image { get; set; }
    }
}
