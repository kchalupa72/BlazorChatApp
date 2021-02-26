using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChat.Data
{
    public class CryptoState
    {
        public List<CryptoData> CryptoDataSet;
        public void SetCryptoState(List<CryptoData> cryptoDataSet) 
        {
            CryptoDataSet = cryptoDataSet;
        }
    }
}
