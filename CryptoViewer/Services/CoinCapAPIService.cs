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
    }
}
