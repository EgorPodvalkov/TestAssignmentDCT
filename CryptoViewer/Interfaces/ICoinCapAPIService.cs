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
    }
}
