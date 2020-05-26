namespace ApiImplementation.Providers
{
	using System.Threading.Tasks;
	using System.Net.Http;
	using GeoIp.Models;
	using GeoIp.Providers;
	using Newtonsoft.Json;

	public class IpStackGeoIpDataProvider : GeoIpDataProvider
	{
		private const string ApiPath = "http://api.ipstack.com/";
		private const string ApiSuffix = "?access_key=6321b3b977c6c1dc41e59b05728d7cd0";

		public override async Task<GeoIpInfo> GetData(string ipOrHostname)
		{
			var returnedApiData = new GeoIpInfo();

			var dataString = await this.GetStringResponseAsync(ApiPath + ipOrHostname);

			var data = JsonConvert.DeserializeObject<IpStackModel>(dataString);

			returnedApiData.Success = true;
			returnedApiData.City = data.City;
			returnedApiData.Country = data.Country_Name;
			returnedApiData.Ip = data.Ip;
			returnedApiData.Latitude = data.Latitude;
			returnedApiData.Longitude = data.Longitude;
			returnedApiData.RegionCode = data.Region_Name;
			returnedApiData.TimeZone = "N/A";
			returnedApiData.ZipCode = data.Zip;

			return returnedApiData;
		}

	}
}