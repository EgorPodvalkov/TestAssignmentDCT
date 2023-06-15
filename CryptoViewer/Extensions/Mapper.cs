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

        public static FullInfoModel ToModel(this FullInfoDeserialized deserializedModel)
        {
            return new FullInfoModel
            {
                Id = deserializedModel.Id,
                Rank = deserializedModel.Rank,
                Symbol = deserializedModel.Symbol,
                Name = deserializedModel.Name,
                Supply = deserializedModel.Supply,
                Cap = deserializedModel.Cap,
                Volume = deserializedModel.Volume,
                Price = deserializedModel.Price,
                ChangePercent = deserializedModel.ChangePercent,
                Link = deserializedModel.Link,
            };
        }

        public static ICollection<Exchange> ToModelList(this ExchangesDeserialized exchangesDeserialized)
        {
            var list = new List<Exchange>();

            foreach (var exchangeDeserialized in exchangesDeserialized.Exchanges)
            {
                list.Add(new Exchange
                {
                    Id = exchangeDeserialized.Name
                });
            }

            return list;
        }


    }
}
