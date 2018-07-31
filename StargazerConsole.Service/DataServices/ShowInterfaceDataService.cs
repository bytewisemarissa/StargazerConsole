using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using NexStar.Net;
using StargazerConsole.Models.Json;

namespace StargazerConsole.DataServices
{
    public interface IShowInterfaceDataService
    {
        List<Parity> GetPossibleParities();
        List<StopBits> GetPossibleStopBits();
        SerialSettings GetDefaultTelescopeSerialSettings();
        SerialSettings GetDefaultFocuserSerialSettings();
        List<string> GetCurrentNexStarPorts();
    }

    public class ShowInterfaceDataService : IShowInterfaceDataService
    {
        private INexStarConnectionManager _nexStarConnectionManager;

        public ShowInterfaceDataService(INexStarConnectionManager nexStarConnectionManager)
        {
            _nexStarConnectionManager = nexStarConnectionManager;
        }

        public List<Parity> GetPossibleParities()
        {
            return Enum.GetValues(typeof(Parity)).Cast<Parity>().ToList();
        }

        public List<StopBits> GetPossibleStopBits()
        {
            return Enum.GetValues(typeof(StopBits)).Cast<StopBits>().ToList();
        }

        public SerialSettings GetDefaultTelescopeSerialSettings()
        {
            return new SerialSettings()
            {
                BaudRate = 9600,
                ParitySetting = Parity.None,
                StopBitsSetting = StopBits.One,
                ReadTimeoutMs = 4000,
                WriteTimeoutMs = 1000,
                IsRetryEnabled = false,
                MaxRetryCount = 0
            };
        }

        public SerialSettings GetDefaultFocuserSerialSettings()
        {
            return new SerialSettings()
            {
                BaudRate = 9600,
                ParitySetting = Parity.None,
                StopBitsSetting = StopBits.One,
                ReadTimeoutMs = 4000,
                WriteTimeoutMs = 1000,
                IsRetryEnabled = false,
                MaxRetryCount = 0
            };
        }

        public List<string> GetCurrentNexStarPorts()
        {
            return _nexStarConnectionManager.ActiveNexStarDevicePortNames;
        }
    }
}
