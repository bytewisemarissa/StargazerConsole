using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StargazerConsole.Configuration;
using StargazerConsole.DependencyInjection;
using StargazerConsole.WebsocketServices;

namespace StargazerConsole.Middleware
{
    public interface IStargazerConsoleWebserviceMiddleware
    {
        Task Middleware(HttpContext context, Func<Task> next);
    }

    public class StargazerConsoleWebserviceMiddleware : IStargazerConsoleWebserviceMiddleware
    {
        private readonly ILogger _logger;
        private readonly ApplicationConfiguration _configuration;

        public StargazerConsoleWebserviceMiddleware(
            ILogger<StargazerConsoleWebserviceMiddleware> logger,
            IOptions<ApplicationConfiguration> configuration)
        {
            _logger = logger;
            _configuration = configuration.Value;

            _logger.LogInformation("Stargazer Console Webservice Middleware has been initalized.");
        }

        public async Task Middleware(HttpContext context, Func<Task> next)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                _logger.LogTrace("Web socket connection opened.");

#pragma warning disable 4014
                //We deliberatly want to run the services without waiting so we can deal with the next request while this one is being handled.
                switch (context.Request.Path)
                {
                    case "/toolbar":
                        _logger.LogTrace("Routing connection to logs websocket service.");
                        System.Net.WebSockets.WebSocket webSocketLog = await context.WebSockets.AcceptWebSocketAsync();
                        var service = ServiceProviderManager.ServiceProvider.GetService<IToolbarSocketService>();
                        await service.AttachService(context, webSocketLog);
                        break;
                    default:
                        _logger.LogTrace($"Requested service route {context.Request.Path} was not found.");
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                }
#pragma warning restore 4014
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.UpgradeRequired;
            }
        }
    }
}
