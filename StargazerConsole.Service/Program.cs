using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NexStar.Net;
using StargazerConsole.DependencyInjection;

namespace StargazerConsole.Service
{
    class Program
    {
        private static ILogger _logger;
        private static ICancellationTokenSourceManager _cancellationTokenSourceManager;
        private static Task _webHostTask;

        static void Main(string[] args)
        {
            _logger = ServiceProviderManager.ServiceProvider.GetService<ILogger<Program>>();

            _logger.LogInformation("Setting up Cancellation Token Source Manager.");
            _cancellationTokenSourceManager = ServiceProviderManager.ServiceProvider.GetService<ICancellationTokenSourceManager>();

            _logger.LogInformation("Starting up telescope services.");
            InitalizeTelescopeServices();

            _logger.LogInformation("Starting up web services.");
            _webHostTask = BuildWebHost(args).RunAsync(_cancellationTokenSourceManager.CancellationTokenSource.Token);
            
            _logger.LogInformation("Start up complete. Switch to async context to continue execution.");
            RunProgram().GetAwaiter().GetResult();
        }

        private static async Task RunProgram()
        {
            while (!_cancellationTokenSourceManager.CancellationTokenSource.IsCancellationRequested)
            {
                //wait loop
                while (!_cancellationTokenSourceManager.CancellationTokenSource.IsCancellationRequested)
                {
                    await Task.Delay(250);
                }

                _cancellationTokenSourceManager.CancellationTokenSource.Cancel();
            }
        }

        private static IWebHost BuildWebHost(string[] args)
        {
            _logger.LogTrace("Loading configuration appsettings.json.");
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            _logger.LogTrace("Building web services container.");
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseConfiguration(config)
                .Build();
        }
        
        private static void InitalizeTelescopeServices()
        {
            var connectionManager = ServiceProviderManager.ServiceProvider.GetService<INexStarConnectionManager>();

            connectionManager.RefreshActiveSerialNexstarDevices();
        }

    }
}
