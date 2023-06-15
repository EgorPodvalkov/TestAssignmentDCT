using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Models
{
    public class FullInfoModel
    {
        public string Id { get; set; }
        public string Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Supply { get; set; }
        public string Cap { get; set; }
        public string Volume { get; set; }
        public string Price { get; set; }
        public string ChangePercent { get; set; }
        public string PercentColor { get; set; }
        public string Link { get; set; }
    }
}
