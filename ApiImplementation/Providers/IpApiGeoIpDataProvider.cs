namespace ApiImplementation.Providers
{
	using System.Net.Http;
    using System.Threading.Tasks;

	public class IpApiGeoIpDataProvider : GeoIpDataProvider
	{
		private const string ApiPath = "http://ip-api.com/json/";

		public override async Task<GeoIpInfo> GetData(string ipOrHostname)
		{
			var returnedApiData = new GeoIpInfo();

			using (var response = await this.ApiClient.GetAsync(ApiPath + ipOrHostname))
			{
				var data = await response.Content.ReadAsAsync<IpApiModel>();

				returnedApiData.Success = true;
				returnedApiData.City = data.City;
				returnedApiData.Country = data.Country;
				returnedApiData.Ip = data.Query;
				returnedApiData.Latitude = data.Lat;
				returnedApiData.Longitude = data.Lon;
				returnedApiData.RegionCode = data.Region;
				returnedApiData.TimeZone = data.Timezone;
				returnedApiData.ZipCode = data.Zip;
			}

			return returnedApiData;
		}
	}
}