using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NexStar.Net.Configuration;
using StargazerConsole.Configuration;
using StargazerConsole.DataServices;
using StargazerConsole.Middleware;
using StargazerConsole.WebsocketServices;

namespace StargazerConsole.DependencyInjection
{
    public class ServiceProviderLogShim { }

    public static class ServiceProviderManager
    {
        public static IServiceProvider ServiceProvider { get; }

        static ServiceProviderManager()
        {
            var serivceCollection = new ServiceCollection();
            var configuration = SetupConfiguration();
            var configurationImediate = GetConfigurationImediate();

            serivceCollection.Configure<ApplicationConfiguration>(configuration);

            serivceCollection.AddLogging(builder =>
            {
                builder.SetMinimumLevel((LogLevel)configurationImediate.ApplicationSettings.MinimumLoggingLevel);
                builder.AddConsole();
            });

            serivceCollection.AddNexStarDotNet();

            AddLocalBindings(serivceCollection);

            ServiceProvider = serivceCollection.BuildServiceProvider();

            ILogger logger = ServiceProvider.GetService<ILogger<ServiceProviderLogShim>>();

            logger.LogTrace("ServiceProviderManager is initalized.");
        }

        private static IConfigurationRoot SetupConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }

        private static ApplicationConfiguration GetConfigurationImediate()
        {
            var configuration = File.ReadAllText(Directory.GetCurrentDirectory() + "/appsettings.json");
            return JsonConvert.DeserializeObject<ApplicationConfiguration>(configuration);
        }

        private static void AddLocalBindings(ServiceCollection serivceCollection)
        {
            serivceCollection.AddSingleton<ICancellationTokenSourceManager, CancellationTokenSourceManager>();
            serivceCollection.AddTransient<IStargazerConsoleWebserviceMiddleware, StargazerConsoleWebserviceMiddleware>();
            serivceCollection.AddTransient<IToolbarSocketService, ToolbarSocketService>();
        }
    }
}
