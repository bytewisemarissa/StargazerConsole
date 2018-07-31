using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StargazerConsole.WebsocketServices
{
    public interface IMessagingSocketService
    {
        Task AttachService(HttpContext context, System.Net.WebSockets.WebSocket socket);
    }

    public class MessagingSocketService : IMessagingSocketService
    {

        public async Task AttachService(HttpContext context, System.Net.WebSockets.WebSocket socket)
        {
        }
    }
}
