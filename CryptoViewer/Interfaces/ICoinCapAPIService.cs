using CryptoViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Interfaces
{
    public interface ICoinCapAPIService
    {
        ICollection<PreviewInfo> GetTopNCryptos(int number);
        FullInfoModel GetFullInfo(string search);
        ICollection<Exchange> GetExchangeList(string id, int limit = 5);
    }
}
