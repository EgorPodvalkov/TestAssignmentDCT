using CryptoViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoViewer.DeserializedModels
{
    public class PreviewInfoDeserialized
    {
        [JsonPropertyName("rank")]
        public string Rank { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("priceUsd")]
        public string Price { get; set; }

        [JsonPropertyName("volumeUsd24Hr")]
        public string Volume { get; set; }

        [JsonPropertyName("changePercent24Hr")]
        public string ChangePercent { get; set; }
    }
}
