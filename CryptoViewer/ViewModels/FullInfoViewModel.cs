using CryptoViewer.Interfaces;
using CryptoViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CryptoViewer.ViewModels
{
    public class FullInfoViewModel
    {
        private readonly ICoinCapAPIService _coinCapService;

        public FullInfoViewModel(ICoinCapAPIService coinCapService)
        {
            _coinCapService = coinCapService;
        }

        private string _id;
        public string Id { get { return _id; } }

        private string _rank;
        public string Rank { get { return _rank; } }
        
        private string _symbol;
        public string Symbol { get { return _symbol; } }
        
        private string _name;
        public string Name { get { return _name; } }
        
        private string _supply;
        public string Supply { get { return _supply; } }
        
        private string _cap;
        public string Cap { get { return _cap; } }
        
        private string _volume;
        public string Volume { get { return _volume; } }
        
        private string _price;
        public string Price { get { return _price; } }
        
        private string _changePercent;
        public string ChangePercent { get { return _changePercent; } }
        
        private string _link;
        public string Link { get { return _link; } }

        private ICollection<Exchange> _exchanges;
        public ICollection<Exchange> Exchanges { get { return _exchanges; } }

        public bool UpdateData(string search)
        {

            // Getting fullInfo
            var fullInfo = _coinCapService.GetFullInfo(search);

            // Checking Crypto is Exist 
            if (fullInfo == null)
                return false;

            // Filling fields
            _id = fullInfo.Id;
            _rank = fullInfo.Rank;
            _symbol = fullInfo.Symbol;
            _name = fullInfo.Name;
            _supply = fullInfo.Supply;
            _cap = fullInfo.Cap;
            _volume = fullInfo.Volume;
            _price = fullInfo.Price;
            _changePercent = fullInfo.ChangePercent;
            _link = fullInfo.Link;

            // Getting Exchanges
            _exchanges = _coinCapService.GetExchangeList(_id);
            AddLinksToExchanges();

            // Candles


            return true;
        }

        private void AddLinksToExchanges()
        {
            foreach (var exchange in _exchanges) 
            {
                switch (exchange.Id)
                {
                    case ("Binance"):
                        exchange.Link = $@"https://www.binance.com/uk-UA/trade/{_symbol}_USDT";
                        break;
                    case ("Coinbase Pro"):
                        exchange.Link = $@"https://www.coinbase.com/ru/price/{_id}";
                        break;
                    case ("Kucoin"):
                        exchange.Link = $@"https://www.kucoin.com/trade/{_symbol}-USDT";
                        break;
                    case ("Kraken"):
                        exchange.Link = $@"https://www.kraken.com/uk-ua/prices/{_id}";
                        break;
                    case ("Bitstamp"):
                        exchange.Link = $@"https://www.bitstamp.net/markets/{_symbol}/usd/";
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
