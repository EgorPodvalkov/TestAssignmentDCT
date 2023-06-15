using CryptoViewer.Interfaces;
using CryptoViewer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.ViewModels
{
    public class MainViewModel
    {
        private readonly ICoinCapAPIService _service;

        public MainViewModel(ICoinCapAPIService service)
        {
            _service = service;
        }

        private ObservableCollection<PreviewInfo> _cryptoList = new ObservableCollection<PreviewInfo>();
        public ObservableCollection<PreviewInfo> CryptoList 
        {
            get
            {
                if (_cryptoList.Count == 0)
                    UpdateCryptoList();

                return _cryptoList;
            }
        }

        public PreviewInfo SelectedCrypto { get; set; }

        public void UpdateCryptoList(int numberOfCrypto = 10)
        {
            var newCryptoList = new ObservableCollection<PreviewInfo>(_service.GetTopNCryptos(numberOfCrypto));
            
            _cryptoList.Clear();

            foreach (var crypto in newCryptoList)
            {
                _cryptoList.Add(crypto);
            }

        }
    }
}
