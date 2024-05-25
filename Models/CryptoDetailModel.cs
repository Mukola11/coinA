using coinA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Models
{
    public class CryptoDetailModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Image { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal Volume { get; set; }
        public List<Market> Markets { get; set; }
        public List<PriceChange> PriceChanges { get; set; }
    }

    public class Market
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class PriceChange
    {
        public DateTime Timestamp { get; set; }
        public decimal Price { get; set; }
    }
}
