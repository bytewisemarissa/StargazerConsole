using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace StargazerConsole
{
    public interface ICancellationTokenSourceManager
    {
        CancellationTokenSource CancellationTokenSource { get; }
    }

    public class CancellationTokenSourceManager : ICancellationTokenSourceManager
    {
        private ILogger _logger;

        public CancellationTokenSource CancellationTokenSource { get; }

        public CancellationTokenSourceManager(ILogger<CancellationTokenSourceManager> logger)
        {
            _logger = logger;
            CancellationTokenSource = new CancellationTokenSource();

            _logger.LogTrace("CancellationTokenSourceManager initalized.");
        }
    }
}
