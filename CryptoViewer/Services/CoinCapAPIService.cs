using CryptoViewer.DeserializedModels;
using CryptoViewer.Extensions;
using CryptoViewer.Interfaces;
using CryptoViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;

namespace CryptoViewer.Services
{
    public class CoinCapAPIService : ICoinCapAPIService
    {
        private HttpClient _client;

        public CoinCapAPIService(HttpClient client)
        {
            _client = client;
        }

        public ICollection<PreviewInfo> GetTopNCryptos(int number)
        {
            // Creating Request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($@"https://api.coincap.io/v2/assets?limit={number}")
            };

            // Handling Responce
            var response = _client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();

            var json = response.Content.ReadAsStringAsync().Result;
                
            // Deserializing
            var responceObj = JsonSerializer.Deserialize<AssetsDeserialized>(json);

            // Mapping
            var result = new List<PreviewInfo>();
            foreach (var deserializedModel in responceObj.CryptoList)
            {
                result.Add(deserializedModel.ToModel());
            }

            return result;
        }

        public FullInfoModel GetFullInfo(string search)
        {
            // Creating Request of Searching by id
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($@"https://api.coincap.io/v2/assets/{search.ToLower()}")
            };

            try
            {
                // Handling Responce
                var response = _client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();
                var json = response.Content.ReadAsStringAsync().Result;

                // Deserializing
                var responceObj = JsonSerializer.Deserialize<AssetsFullInfoDeserialized>(json);

                return responceObj.CryptoList[0].ToModel();
            }
            catch 
            {
                // Creating Request by Searching by Symbol or Name
                request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($@"https://api.coincap.io/v2/assets")
                };

                // Handling Responce
                var response = _client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();
                var json = response.Content.ReadAsStringAsync().Result;

                // Deserializing
                var responceObj = JsonSerializer.Deserialize<AssetsFullInfoDeserialized>(json);

                // Searching
                try
                {
                    var findedObj = responceObj
                        .CryptoList
                        .First(x => 
                        x.Name.ToLower() == search.ToLower() || 
                        x.Symbol == search.ToUpper());

                    return findedObj.ToModel();
                }
                catch 
                {
                    return null;
                }
            }
        }

        public ICollection<Exchange> GetExchangeList(string id, int limit = 10)
        {
            // Creating Request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($@"https://api.coincap.io/v2/assets/{id}/markets?limit={limit * 3}")
            };

            // Handling Responce
            var response = _client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();

            var json = response.Content.ReadAsStringAsync().Result;

            // Deserializing
            var responceObj = JsonSerializer.Deserialize<ExchangesDeserialized>(json);

            return responceObj.ToModelList(limit);
        }
    }
}
