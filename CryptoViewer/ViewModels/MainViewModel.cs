using CryptoViewer.Interfaces;
using System;
using System.Collections.Generic;
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
    }
}
