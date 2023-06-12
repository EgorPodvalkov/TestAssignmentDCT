using CryptoViewer.Interfaces;
using CryptoViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Services
{
    public class CoinCapAPIService : ICoinCapAPIService
    {
        public ICollection<PreviewInfo> GetTopNCryptos(int number)
        {
            throw new NotImplementedException();
        }
    }
}
