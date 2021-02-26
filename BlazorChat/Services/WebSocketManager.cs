using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorChat.Services
{
    public class WebSocketManager
    {
        private WebSocket websocket;

        private async Task Test(WebSocket webSocket) 
        {
            
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult initResult = await websocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!initResult.CloseStatus.HasValue) 
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            }

            await webSocket.CloseAsync(initResult.CloseStatus.Value, initResult.CloseStatusDescription, CancellationToken.None);
        }
    }
}
