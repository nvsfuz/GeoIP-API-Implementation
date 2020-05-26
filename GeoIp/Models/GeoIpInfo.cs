namespace GeoIp.Models
{
    public class GeoIpInfo
    {
        public GeoIpInfo() { }
        public GeoIpInfo(string ip)
        {
	        this.Ip = ip;
        }

        public bool Success { get; internal set; } = false;
        public string Ip { get; internal set; }
        public string TimeZone { get; internal set; }
        public string Country { get; internal set; }
        public string RegionCode { get; internal set; }
        public string City { get; internal set; }
        public string ZipCode { get; internal set; }
        public double? Latitude { get; internal set; }
        public double? Longitude { get; internal set; }
    }
}
