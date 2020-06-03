namespace GeoIp.Models
{
    public class IpStackModel : IApiDataModel
    {
        public bool Success { get; set; }
        public string Ip { get; set; }
        public string Country_Name { get; set; }
        public string City { get; set; }
        public string Region_Name { get; set; }
        public string Zip { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
