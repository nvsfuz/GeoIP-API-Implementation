namespace GeoIp.Providers
{
	using System.Threading.Tasks;
	using Models;
	using Newtonsoft.Json;

	public class IpApiGeoIpDataProvider : GeoIpDataProvider<IpApiModel>
	{
		private const string ApiPath = "http://ip-api.com/json/";

		protected override async Task<GeoIpInfo> AdaptToTargetModel(IpApiModel data)
		{
			var returnedApiData = new GeoIpInfo
			{
				Success = true,
				City = data.City,
				Country = data.Country,
				Ip = data.Query,
				Latitude = data.Lat,
				Longitude = data.Lon,
				RegionCode = data.Region,
				TimeZone = data.Timezone,
				ZipCode = data.Zip
			};

			return returnedApiData;
		}

		protected override async Task<string> CallTheApi(string ipOrHostname)
		{
			return await this.GetStringResponseAsync(ApiPath + ipOrHostname);
		}
	}
}