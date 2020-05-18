namespace ApiImplementation.Providers
{
	using System.Threading.Tasks;
    using System.Net.Http;

    public class IpStackGeoIpDataProvider : GeoIpDataProvider
	{
		private readonly string ApiPath = "http://api.ipstack.com/";
		private readonly string ApiSuffix = "?access_key=6321b3b977c6c1dc41e59b05728d7cd0";

		public override async Task<GeoIpInfo> GetData(string ipOrHostname)
		{
			GeoIpInfo returnedApiData = new GeoIpInfo();

			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(ApiPath + ipOrHostname + ApiSuffix))
			{
				IpStackModel data = await response.Content.ReadAsAsync<IpStackModel>();

				returnedApiData.Success = true;
				returnedApiData.City = data.City;
				returnedApiData.Country = data.Country_Name;
				returnedApiData.Ip = data.Ip;
				returnedApiData.Latitude = data.Latitude;
				returnedApiData.Longitude = data.Longitude;
				returnedApiData.RegionCode = data.Region_Name;
				returnedApiData.TimeZone = "N/A";
				returnedApiData.ZipCode = data.Zip;
			}

			return returnedApiData;
		}
	}
}
