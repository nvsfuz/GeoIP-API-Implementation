namespace ApiImplementation.Providers
{
	using System.Threading.Tasks;
	using System.Net.Http;
	using GeoIp.Models;
	using GeoIp.Providers;
	using Newtonsoft.Json;

	public class IpStackGeoIpDataProvider : GeoIpDataProvider<IpStackModel>
	{
		private const string ApiPath = "http://api.ipstack.com/";
		private const string ApiSuffix = "?access_key=6321b3b977c6c1dc41e59b05728d7cd0";

		protected override async Task<GeoIpInfo> AdaptToTargetModel(IpStackModel data)
		{
			var returnedApiData = new GeoIpInfo
			{
				Success = true,
				City = data.City,
				Country = data.Country_Name,
				Ip = data.Ip,
				Latitude = data.Latitude,
				Longitude = data.Longitude,
				RegionCode = data.Region_Name,
				TimeZone = "N/A",
				ZipCode = data.Zip
			};

			return returnedApiData;
		}

		protected override async Task<string> CallTheApi(string ipOrHostname)
		{
			return await this.GetStringResponseAsync(ApiPath + ipOrHostname + ApiSuffix);
		}
	}
}