using BlazorChat.Data;
using System.Threading.Tasks;

namespace BlazorChat.SignalRServer
{
    public interface ICryptoHub
    {
        Task SendCryptoDataToClients(CryptoData quote);
    }
}
