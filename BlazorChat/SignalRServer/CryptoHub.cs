using BlazorChat.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace BlazorChat.SignalRServer
{
    public class CryptoHub : Hub<ICryptoHub>
    {
        public const string HubUrl = "/crypto";

        public async Task SendCryptoData(CryptoData cryptoData)
        {
            await Clients.All.SendCryptoDataToClients(cryptoData);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
    }
}
