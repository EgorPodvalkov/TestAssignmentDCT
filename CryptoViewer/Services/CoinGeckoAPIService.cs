using CryptoViewer.DeserializedModels;
using CryptoViewer.Interfaces;
using CryptoViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoViewer.Services
{
    public class CoinGeckoAPIService : ICoinGeckoAPIService
    {
        private HttpClient _client;

        public CoinGeckoAPIService(HttpClient client)
        {
            _client = client;
        }

        public ICollection<Candle> GetCandles(string id)
        {
            // Creating Request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($@"https://api.coingecko.com/api/v3/coins/{id}/ohlc?vs_currency=usd&days=1")
            };

            // Handling Response
            var response = _client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();

            var json = response.Content.ReadAsStringAsync().Result;

            // Deserializing
            var responseObj = JsonSerializer.Deserialize<List<List<double>>>(json);

            var candles = new List<Candle>();
            foreach (var candle in responseObj)
            {
                candles.Add(new Candle
                {
                    Open = candle[1],
                    High = candle[2],
                    Low = candle[3],
                    Close = candle[4]
                });
            }

            return candles;
        }
    }
}
