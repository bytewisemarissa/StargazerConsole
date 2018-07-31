using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StargazerConsole.WebsocketServices
{
    public interface IToolbarSocketService
    {
        Task AttachService(HttpContext context, System.Net.WebSockets.WebSocket socket);
    }

    public class ToolbarSocketService : IToolbarSocketService
    {

        public async Task AttachService(HttpContext context, System.Net.WebSockets.WebSocket socket)
        {
        }
    }
}
