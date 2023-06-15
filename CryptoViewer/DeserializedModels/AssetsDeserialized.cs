using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoViewer.DeserializedModels
{
    public class AssetsDeserialized
    {
        [JsonPropertyName("data")]
        public PreviewInfoDeserialized[] CryptoList { get; set; } = Array.Empty<PreviewInfoDeserialized>();
    }
}
