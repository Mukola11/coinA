using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Models
{
    public class TopCryptoModel
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal CurrentPrice { get; set; }
        public long MarketCap { get; set; }
        public long TotalVolume { get; set; }

    }
}
