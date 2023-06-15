using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoViewer.DeserializedModels
{
    public class ExchangesDeserialized
    {
        [JsonPropertyName("data")]
        public ExchangeDeserialized[] Exchanges { get; set; } = Array.Empty<ExchangeDeserialized>();
    }
}
