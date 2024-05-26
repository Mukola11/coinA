using coinA.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Models
{
    public class CryptoDetailModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("image")]
        public ImageData Image { get; set; }

        [JsonProperty("market_data")]
        public MarketData MarketData { get; set; }

        public decimal CurrentPriceUSD => MarketData?.CurrentPrice != null && MarketData.CurrentPrice.ContainsKey("usd")
        ? MarketData.CurrentPrice["usd"]
        : 0;

        public decimal VolumeUSD => MarketData?.TotalVolume != null && MarketData.TotalVolume.ContainsKey("usd")
        ? MarketData.TotalVolume["usd"]
        : 0;

        [JsonProperty("tickers")]
        public List<Ticker> Tickers { get; set; }

        public List<Market> Markets { get; set; }
        public List<PriceChange> PriceChanges { get; set; }
    }

    
}
