using coinA.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Services
{
    public class CryptoApiService
    {
        private readonly HttpClient _httpClient;

        public CryptoApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<TopCryptoModel>> GetTopCryptosAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, CryptoApiUrls.GetTopCryptosUrl());
                request.Headers.Add("User-Agent", "coinA");

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<TopCryptoModel>>(responseBody);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }


        public async Task<CryptoDetailModel> GetCryptoDetailAsync(string id)
        {
            try
            {
                var cryptoDetail = await FetchCryptoDetailAsync(id);
                if (cryptoDetail != null)
                {
                    var priceChanges = await FetchPriceChangesAsync(id);
                    if (priceChanges != null)
                    {
                        cryptoDetail.PriceChanges = priceChanges;
                    }
                }

                return cryptoDetail;
            }
            catch
            {
                return null;
            }
        }


        private async Task<CryptoDetailModel> FetchCryptoDetailAsync(string id)
        {
            try
            {
                string url = CryptoApiUrls.GetCryptoDetailUrl(id);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("User-Agent", "coinA");

                var response = await _httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CryptoDetailModel>(responseBody);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }


        private async Task<List<PriceChange>> FetchPriceChangesAsync(string id)
        {
            try
            {
                string url = CryptoApiUrls.GetCryptoPriceChangesUrl(id);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("User-Agent", "coinA");

                var response = await _httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var priceChangeData = JsonConvert.DeserializeObject<JObject>(responseBody);

                    var priceChangeArray = priceChangeData["prices"] as JArray;
                    var priceChanges = new List<PriceChange>();
                    foreach (var item in priceChangeArray)
                    {
                        var timestamp = item[0].ToObject<long>();
                        var price = item[1].ToObject<decimal>();
                        priceChanges.Add(new PriceChange { Timestamp = timestamp, Price = price });
                    }

                    return priceChanges;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }


        public async Task<List<SearchCryptoModel>> SearchCryptosAsync(string query)
        {
            try
            {
                string url = CryptoApiUrls.GetSearchCryptoUrl(query);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("User-Agent", "coinA");

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var searchResponse = JsonConvert.DeserializeObject<SearchResponse>(responseBody);
                    return searchResponse.Coins;
                }
                else
                {
                    return new List<SearchCryptoModel>();
                }
            }
            catch
            {
                return new List<SearchCryptoModel>();
            }
        }
    }
}
