using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NexStar.Net.Configuration;
using StargazerConsole.DataServices;
using StargazerConsole.DependencyInjection;
using StargazerConsole.Middleware;

namespace StargazerConsole
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private ILogger _logger;

        public Startup(ILogger<Startup> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddNexStarDotNet();
            services.AddTransient<IShowInterfaceDataService, ShowInterfaceDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            _logger.LogTrace("Setting http host.");

            app.UseStaticFiles();
            app.UseExceptionHandler("/Interface/Error");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{Controller=Interface}/{action=ShowInterface}/{id?}");
            });

            _logger.LogTrace("Setting web socket options. KeepAlive = 30 seconds. RecieveBufferSize = 4096");
            app.UseWebSockets(new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(30),
                ReceiveBufferSize = 4096
            });

            _logger.LogTrace("Setting web socket service routing.");
            var websocketMiddleware =
                ServiceProviderManager.ServiceProvider.GetService<IStargazerConsoleWebserviceMiddleware>();
            app.Use(websocketMiddleware.Middleware);
        }
    }
}
