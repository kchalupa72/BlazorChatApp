using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorChat.SignalRServer;
using System.Threading;
using BlazorChat.Data;

namespace BlazorChat.Services
{
    public class CryptoBackgroundWorker : BackgroundService
    {
        private readonly IHubContext<CryptoHub, ICryptoHub> CryptoHub;
        private readonly ICryptoGenerator CryptoGenerator;

        public CryptoBackgroundWorker(IHubContext<CryptoHub, ICryptoHub> hubContext, ICryptoGenerator cryptoGenerator) 
        {
            CryptoHub = hubContext;
            CryptoGenerator = cryptoGenerator;
        }

        protected override async Task ExecuteAsync(CancellationToken cancelToken)
        {
            this.CryptoGenerator.CryptoUpdate += HandleQuoteUpdate;

            await this.CryptoGenerator.RunAsync(cancelToken);

            this.CryptoGenerator.CryptoUpdate -= HandleQuoteUpdate;
        }

        private async void HandleQuoteUpdate(object sender, CryptoData quote) 
        {
            await CryptoHub.Clients.All.SendCryptoDataToClients(quote);
        }


    }
}
