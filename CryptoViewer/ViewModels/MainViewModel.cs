﻿using CryptoViewer.Interfaces;
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
        private ICoinCapAPIService _service;

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
                    _cryptoList = new ObservableCollection<PreviewInfo>(_service.GetTopNCryptos(10));

                return _cryptoList;
            }  
        }

        public PreviewInfo SelectedCrypto { get; set; }
    }
}
