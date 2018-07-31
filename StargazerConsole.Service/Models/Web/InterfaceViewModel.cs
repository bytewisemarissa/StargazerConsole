using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using NexStar.Net.NexstarSupport.Models;
using StargazerConsole.Models.Json;

namespace StargazerConsole.Models.Web
{
    public class InterfaceViewModel
    {
        public List<Parity> AllowedParities { get; set; }
        public List<StopBits> AllowedStopBits { get; set; }
        public List<string> CurrentNexStarPorts { get; set; }
        public SerialSettings TelescopeSerialSettings { get; set; }
        public SerialSettings FocuserSerialSettings { get; set; }
        public GpsData TelescopeGpsData { get; set; }
    }
}
