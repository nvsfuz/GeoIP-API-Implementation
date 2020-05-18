namespace ApiImplementation.Old
{
	using System.Net.Http;
	using System.Threading.Tasks;

	//design pattern Provider

    public class GeoIpService
    {
        /// <summary>
        /// Method obtains information from API based on user input.
        /// </summary>
        /// <param name="ipOrHostname">IP or Hostname of desired domain.</param>
        /// <param name="apiChoice">The choice of API to get info from. 1: ip-api. 2: ipstack.</param>
        /// <returns></returns>
        public static async Task<GeoIpInfo> GetGeoIpInfo(string ipOrHostname, int apiChoice)
        {
            GeoIpInfo returnedApiData = new GeoIpInfo();

            string ApiPath = "";

            // Creating the url based on API chosen
            if (apiChoice == 1)
            {
                ApiPath = "http://ip-api.com/json/" + ipOrHostname;
            }
            else if (apiChoice == 2)
            {
                ApiPath = "http://api.ipstack.com/" + ipOrHostname + "?access_key=6321b3b977c6c1dc41e59b05728d7cd0";
            }

            // Awaits a response from the API
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(ApiPath))
            {
                // If API response is successful, depending on what API was chosen, 
                // objects are created and populated. 
                if (response.IsSuccessStatusCode && apiChoice == 1)
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
                else if (response.IsSuccessStatusCode && apiChoice == 2 && ipOrHostname != "")
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
                else
                {
                    returnedApiData.City = "";
                    returnedApiData.Country = "";
                    returnedApiData.Ip = "";
                    returnedApiData.RegionCode = "";
                    returnedApiData.TimeZone = "";
                    returnedApiData.ZipCode = "";
                    returnedApiData.Longitude = null;
                    returnedApiData.Latitude = null;
                }

                return returnedApiData;
            }
        }
    }
}
