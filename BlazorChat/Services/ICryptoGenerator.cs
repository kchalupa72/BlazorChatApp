using BlazorChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorChat.Services
{
    public interface ICryptoGenerator
    {
        event EventHandler<CryptoData> CryptoUpdate;

        Task RunAsync(CancellationToken cancelToken);
    }
}
