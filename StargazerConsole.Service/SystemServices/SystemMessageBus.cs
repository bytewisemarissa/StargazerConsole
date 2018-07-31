using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StargazerConsole.SystemServices
{
    public class SystemMessageBus
    {
        private ILogger _logger;

        public SystemMessageBus(ILogger<SystemMessageBus> logger)
        {
            _logger = logger;
        }
    }
}
