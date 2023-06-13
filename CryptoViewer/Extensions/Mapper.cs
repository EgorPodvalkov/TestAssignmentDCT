using CryptoViewer.DeserializedModels;
using CryptoViewer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Extensions
{
    public static class Mapper
    {
        public static PreviewInfo ToModel(this PreviewInfoDeserialized deserializedModel, int priceLength = 7)
        {
            // Cutting Price
            var price = deserializedModel.Price;
            if(price.Length > priceLength)
                price = price.Substring(0, priceLength);

            // Cutting Volume
            var volume = deserializedModel.Volume;
            var index = volume.IndexOf(".");
            if (index != -1)
                volume = volume.Substring(0, index);

            // Cutting Percentage
            var percentage = deserializedModel.ChangePercent;
            index = percentage.IndexOf(".");
            if (index != -1 && index + 3 < percentage.Length)
                percentage = percentage.Substring(0, index + 3);

            // Getting Color of Percentage
            var percentageColor = "LightGreen";
            if (percentage[0] == '-')
                percentageColor = "Red";

            return new PreviewInfo
            {
                Rank = int.Parse(deserializedModel.Rank),
                Symbol = deserializedModel.Symbol,
                Price = price + " $",
                Volume = volume + " $",
                ChangePercent = percentage + " %",
                ChangePercentColor = percentageColor
            };
        }
    }
}
