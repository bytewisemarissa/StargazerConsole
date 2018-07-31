using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;

namespace StargazerConsole.Models.Json
{
    public class SerialSettings
    {
        [DisplayName("Baud Rate")]
        [Description("The baud rate for the serial connection.")]
        public int BaudRate { get; set; }

        [DisplayName("Parity")]
        [Description("The parity for the serial connection.")]
        public Parity ParitySetting { get; set; }

        [DisplayName("Stop Bits")]
        [Description("The stopbits for the serial connection.")]
        public StopBits StopBitsSetting { get; set; }

        [DisplayName("Read Timeout MS")]
        [Description("How long to wait when reading from the device.")]
        public int ReadTimeoutMs { get; set; }

        [DisplayName("Write Timeout MS")]
        [Description("How long to wait when writing to the device.")]
        public int WriteTimeoutMs { get; set; }

        [DisplayName("Retry Serial Connection?")]
        public bool IsRetryEnabled { get; set; }

        [DisplayName("Max Retry Count")]
        [Description("How many times the connection whould be retried.")]
        public int MaxRetryCount { get; set; }
    }
}
