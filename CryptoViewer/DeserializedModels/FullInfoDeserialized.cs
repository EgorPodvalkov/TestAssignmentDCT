using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoViewer.DeserializedModels
{
    public class FullInfoDeserialized
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("rank")]
        public string Rank { get; set; }
        
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("supply")]
        public string Supply { get; set; }
        
        [JsonPropertyName("marketCapUsd")]
        public string Cap { get; set; }
        
        [JsonPropertyName("volumeUsd24Hr")]
        public string Volume { get; set; }
        
        [JsonPropertyName("priceUsd")]
        public string Price { get; set; }
        
        [JsonPropertyName("changePercent24Hr")]
        public string ChangePercent { get; set; }
        
        [JsonPropertyName("explorer")]
        public string Link { get; set; }
    }
}
