using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Services
{
    public static class CryptoApiUrls
    {
        public const string BaseUrl = "https://api.coingecko.com/api/v3/";
        public static string GetTopCryptosUrl() => $"{BaseUrl}coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1&sparkline=false";
        public static string GetCryptoDetailUrl(string id) => $"{BaseUrl}coins/{id}";
        public static string GetCryptoPriceChangesUrl(string id) => $"{BaseUrl}coins/{id}/market_chart?vs_currency=usd&days=1";
        public static string GetSearchCryptoUrl(string query) => $"{BaseUrl}search?query={query}";

    }
}
