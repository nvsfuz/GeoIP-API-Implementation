namespace GeoIp.Providers
{
	using System.Threading.Tasks;
	using Models;
	using Newtonsoft.Json;

	public class IpApiGeoIpDataProvider : GeoIpDataProvider
	{
		private const string ApiPath = "http://ip-api.com/json/";

		public override async Task<GeoIpInfo> GetData(string ipOrHostname)
		{
			var returnedApiData = new GeoIpInfo();

			var dataString = await this.GetStringResponseAsync(ApiPath + ipOrHostname);

			var data = JsonConvert.DeserializeObject<IpApiModel>(dataString);

			returnedApiData.Success = true;
			returnedApiData.City = data.City;
			returnedApiData.Country = data.Country;
			returnedApiData.Ip = data.Query;
			returnedApiData.Latitude = data.Lat;
			returnedApiData.Longitude = data.Lon;
			returnedApiData.RegionCode = data.Region;
			returnedApiData.TimeZone = data.Timezone;
			returnedApiData.ZipCode = data.Zip;

			return returnedApiData;
		}
	}
}