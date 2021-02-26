using BlazorChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorChat.Services
{
    public class CryptoGenerator : ICryptoGenerator
    {
        public event EventHandler<CryptoData> CryptoUpdate;

        private CryptoDataService CryptoService;

        public CryptoGenerator(CryptoDataService cryptoService) 
        {
            CryptoService = cryptoService;
        }

        public async Task RunAsync(CancellationToken cancelToken) 
        {
            await Task.Delay(1000);

            while (!cancelToken.IsCancellationRequested) 
            {
                Random randomIndexGenerator = new Random();
                var randomIndex =  randomIndexGenerator.Next(0, CryptoService.GetCryptoQuotesCount());
                RandomizeCryptoQuote(CryptoService.GetAllCryptoData()[randomIndex]);
                await Task.Delay(200);
            }

            //set a delay
            await Task.Delay(1000);
        }

        private void RandomizeCryptoQuote(CryptoData cryptoData) 
        {
            Random randomPriceChangeGenerator = new Random();
            Random randomVolume = new Random();

            var randomPercentagePriceChange = (randomPriceChangeGenerator.NextDouble() + randomPriceChangeGenerator.Next(0, 2)) * .01;
            randomPercentagePriceChange = (randomPriceChangeGenerator.Next(0, 1) == 0) ? randomPercentagePriceChange : randomPercentagePriceChange * -.30;
            //randomize with new values
            var newPrice = cryptoData.Price * (((randomPriceChangeGenerator.NextDouble() - 0.48d) / 1000d) + 1d);
            cryptoData.Price = Math.Round(newPrice, 2);
            cryptoData.Volume = (int)(randomVolume.NextDouble() * 3000d / newPrice);
            cryptoData.Time = DateTime.Now;

            CryptoUpdate?.Invoke(this, cryptoData);
        }

    }
}
