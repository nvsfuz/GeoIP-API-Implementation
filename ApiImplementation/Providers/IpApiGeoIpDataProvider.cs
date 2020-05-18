namespace ApiImplementation.Providers
{
	using System.Net.Http;
    using System.Threading.Tasks;

	public class IpApiGeoIpDataProvider : GeoIpDataProvider
	{
		private string ApiPath = "http://ip-api.com/json/";

		public override async Task<GeoIpInfo> GetData(string ipOrHostname)
		{
			GeoIpInfo returnedApiData = new GeoIpInfo();

			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(ApiPath + ipOrHostname))
			{
				IpApiModel data = await response.Content.ReadAsAsync<IpApiModel>();

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