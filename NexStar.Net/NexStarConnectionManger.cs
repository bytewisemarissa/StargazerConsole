using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NexStar.Net.NexstarSupport.Commands;
using NexStar.Net.SerialMgmt;
using NexStar.Net.Exceptions;

namespace NexStar.Net
{
    public interface INexStarConnectionManager
    {
        List<string> ActiveNexStarDevicePortNames { get; }
        Dictionary<Guid, NexStarConnection> Connections { get; }
        NexStarConnection DefaultConnection { get; }
        Guid CreateConnectionForAddress(string serialComAddress);
        void RefreshActiveSerialNexstarDevices();
        void SetDefaultConnection(Guid deviceId);
    }

    public class NexStarConnectionManager : INexStarConnectionManager
    {
        private ILogger<NexStarConnectionManager> _logger;

        public List<string> ActiveNexStarDevicePortNames { get; }

        public Dictionary<Guid, NexStarConnection> Connections { get; }

        private Guid _defaultDeviceGuid = Guid.Empty;

        public NexStarConnection DefaultConnection
        {
            get
            {
                if (_defaultDeviceGuid == Guid.Empty)
                    return null;

                return Connections[_defaultDeviceGuid];
            }
        }

        public NexStarConnectionManager(ILogger<NexStarConnectionManager> logger)
        {
            _logger = logger;

            ActiveNexStarDevicePortNames = new List<string>();
            Connections = new Dictionary<Guid, NexStarConnection>();
        }

        public Guid CreateConnectionForAddress(string serialComAddress)
        {
            if (!ActiveNexStarDevicePortNames.Contains(serialComAddress))
            {
                throw new ArgumentException("The port address identified is not a nexstar device. Ensure that you have run RefreshActiveSerialNexstarDevices() before starting a connection.");
            }

            var identifier = Guid.NewGuid();
            Connections.Add(identifier, new NexStarConnection(serialComAddress));
            return identifier;
        }
        
        public void RefreshActiveSerialNexstarDevices()
        {
            _logger.LogInformation("Clearing old devices.");
            ActiveNexStarDevicePortNames.Clear();

            _logger.LogInformation("Starting probe for NexStar devices.");

            string[] portNames = SerialPort.GetPortNames();
            foreach (string portName in portNames)
            {
                SerialPortController testController = new SerialPortController(portName);
                VersionCommand versionCommandCommand = new VersionCommand();
                try
                {
                    testController.RunCommand(versionCommandCommand);

                    if (versionCommandCommand.RawResultBytes != null)
                    {
                        ActiveNexStarDevicePortNames.Add(portName);
                        _logger.LogInformation($"NexStar device found on port '{portName}'.");
                    }
                }
                catch (TimeoutException)
                {
                    _logger.LogInformation($"Probe timeout for port '{portName}'.");
                    //ignore timeouts here, we are expecting some devices to not respond.
                }
                finally
                {
                    testController.CloseSerialConnection();
                }
            }

            _logger.LogInformation($"Probe finished found {ActiveNexStarDevicePortNames.Count} devices.");
        }

        public void SetDefaultConnection(Guid deviceId)
        {
            if (!Connections.ContainsKey(deviceId))
            {
                throw new ArgumentException("The passed device id is not valid.");
            }

            _defaultDeviceGuid = deviceId;

            _logger.LogInformation($"Default connection set to id '{deviceId}'.");
        }
    }
}
