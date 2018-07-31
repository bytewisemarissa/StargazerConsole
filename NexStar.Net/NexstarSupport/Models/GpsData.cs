using System;
using System.ComponentModel;

namespace NexStar.Net.NexstarSupport.Models
{
    public class GpsData
    {
        [DisplayName("Degrees Latitude")]
        public Int16 DegreesLatitude { get; set; }
        [DisplayName("Minutes Latitude")]
        public Int16 MinutesLatitude { get; set; }
        [DisplayName("Seconds Latitude")]
        public Int16 SecondsLatitude { get; set; }
        [DisplayName("Is North?")]
        public Boolean IsNorth { get; set; }
        [DisplayName("Degrees Longitude")]
        public Int16 DegreesLongitude { get; set; }
        [DisplayName("Minutes Longitude")]
        public Int16 MinutesLongitude { get; set; }
        [DisplayName("Seconds Longitude")]
        public Int16 SecondsLongitude { get; set; }
        [DisplayName("Is West?")]
        public Boolean IsWest { get; set; }

        public GpsData() { }

        public GpsData(byte[] rawBytes)
        {
            DegreesLatitude = Convert.ToInt16(rawBytes[0]);
            MinutesLatitude = Convert.ToInt16(rawBytes[1]);
            SecondsLatitude = Convert.ToInt16(rawBytes[2]);
            IsNorth = !Convert.ToBoolean(rawBytes[3]);
            DegreesLongitude = Convert.ToInt16(rawBytes[4]);
            MinutesLongitude = Convert.ToInt16(rawBytes[5]);
            SecondsLongitude = Convert.ToInt16(rawBytes[6]);
            IsWest = Convert.ToBoolean(rawBytes[7]);
        }

        public override string ToString()
        {
            return $"{(IsNorth ? "N" : "S")}{DegreesLatitude}°{MinutesLatitude}'{SecondsLatitude}\"|{(IsWest ? "W" : "E")}{DegreesLongitude}°{MinutesLongitude}'{SecondsLongitude}\"";
        }
    }
}
