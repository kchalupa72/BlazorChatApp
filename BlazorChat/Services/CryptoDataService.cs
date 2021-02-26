using BlazorChat.Data;
using BlazorChat.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChat.Services
{
    public class CryptoDataService
    {

        private CryptoDataRepo CryptoRepo;
        public CryptoDataService(CryptoDataRepo cryptoRepo) 
        {
            CryptoRepo = cryptoRepo;
        }

        public List<CryptoData> GetAllCryptoData() 
        {
            return CryptoRepo.GetAllCryptoQuotes();
        }

        public void SetCryptoPrice(string symbol, double price) 
        {
            CryptoRepo.SetNewCryptoPrice(symbol, price);
        }

        public void SetCryptoQuote(CryptoData cryptoData) 
        {
            CryptoRepo.SetNewCryptoQuote(cryptoData);
        }

        public int GetCryptoQuotesCount() 
        {
            return CryptoRepo.GetAllCryptoQuotes().Count;
        }

        public void SendUpdateToClient() 
        {
            
        }

    }
}
