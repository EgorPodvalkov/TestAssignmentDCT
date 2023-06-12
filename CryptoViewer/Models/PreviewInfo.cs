using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Models
{
    public class PreviewInfo
    {
        // rank
        public int Rank { get; set; }

        // symbol
        public string Symbol { get; set; } = "";

        // priceUsd
        public decimal Price { get; set; }

        // volumeUsd24Hr
        public decimal Volume { get; set; }

        // changePercent24Hr
        public decimal ChangePercent { get; set; }
    }
}
