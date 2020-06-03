﻿namespace GeoIp.Models
{
	public class IpApiModel : IApiDataModel
    {
        public string Status { get; set; }
        public string Query { get; set; }
        public string Timezone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Zip { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
    }
}
