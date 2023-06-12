using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoViewer.Models
{
    public class PreviewInfo
    {
        public int Rank { get; set; }

        public string Symbol { get; set; } = "";

        public string Price { get; set; }

        public string Volume { get; set; }

        public string ChangePercent { get; set; }
    }
}
