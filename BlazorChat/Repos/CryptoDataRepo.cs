using BlazorChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChat.Repos
{
    public class CryptoDataRepo
    {
        private List<CryptoData> CryptoDataSet;

        public CryptoDataRepo() 
        {
            CryptoDataSet = SeedCryptoData();
        }


        private List<CryptoData> SeedCryptoData()
        {
            return new List<CryptoData>()
            {
                new CryptoData() { Symbol = "BTC", Price = 50000.00, BasePrice = 50000.00, Volume = 2000 },
                new CryptoData() { Symbol = "D", Price = 1000.05, BasePrice = 1000.05, Volume = 2000 },
                new CryptoData() { Symbol = "LTC", Price = 12000.25, BasePrice = 12000.25, Volume = 2000 }
            };
        }

        public void SetNewCryptoQuote(CryptoData cryptoData) 
        {
            var originalElement = CryptoDataSet.Single(e => e.Symbol == cryptoData.Symbol);
            var index = CryptoDataSet.IndexOf(originalElement);
            
            CryptoDataSet[index] = cryptoData;
        }

        public void SetNewCryptoPrice(string symbol, double price) 
        {
            var element = CryptoDataSet.Single(e => e.Symbol == symbol);
            var index = CryptoDataSet.IndexOf(element);
            element.Price = price;
            CryptoDataSet[index] = element;
        }

        public double GetCryptoQuote(string symbol) 
        {
            return CryptoDataSet.Single(e => e.Symbol == symbol).Price;
        }

        public List<CryptoData> GetAllCryptoQuotes() 
        {
            return CryptoDataSet;
        }

        public void SetCryptoDataSet(List<CryptoData> cryptoDatas) 
        {
            CryptoDataSet = cryptoDatas;
        }



    }
}
