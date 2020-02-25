using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiImplementation
{
    public class GeoIpService
    {
        /// <summary>
        /// Method obtains information from API based on user input.
        /// Overloaded with IP or a Hostname.
        /// </summary>
        /// <param name="IpOrHostname"></param>
        /// <returns></returns>
        public static async Task<GeoIpInfo> GetGeoIpInfo(string IpOrHostname)
        {
            string url = "";
            int apiChoice = 0;

            // Loop will continue to ask for int 1 or 2 until one is chosen.
            do
            {
                try
                {
                    Console.Clear();
                    Console.Write("Would you like to use api.ipstack or ip.api?\n1: api.ipstack\n2: ip.api\nChoice: ");
                    apiChoice = Convert.ToInt32(Console.ReadLine());
                    if (apiChoice != 1 && apiChoice != 2)
                    {
                        Console.WriteLine("Your input must be either 1 or 2!");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.WriteLine("Your input must be either 1 or 2!");
                    Console.ReadKey();
                }
            } while (apiChoice != 1 && apiChoice != 2);

            // Creating the url based on API chosen
            if (apiChoice == 1)
            {
                url = "http://ip-api.com/json/" + IpOrHostname;
            }
            else if (apiChoice == 2)
            {
                url = "http://api.ipstack.com/" + IpOrHostname + "?access_key=6321b3b977c6c1dc41e59b05728d7cd0";
            }

            GeoIpInfo trueData = new GeoIpInfo();

            // Awaits a response from the API
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                // If API response is successful, depending on what API was chosen, 
                // objects are created and populated. 
                if (response.IsSuccessStatusCode && apiChoice == 1)
                {
                    IpApiModel data;
                    data = await response.Content.ReadAsAsync<IpApiModel>();

                    trueData.Success = true;
                    trueData.City = data.City;
                    trueData.Country = data.Country;
                    trueData.Ip = data.Query;
                    trueData.Latitude = data.Lat;
                    trueData.Longitude = data.Lon;
                    trueData.RegionCode = data.Region;
                    trueData.TimeZone = data.Timezone;
                    trueData.ZipCode = data.Zip;
                }
                else if (response.IsSuccessStatusCode && apiChoice == 2 && IpOrHostname != "")
                {
                    IpStackModel data;
                    data = await response.Content.ReadAsAsync<IpStackModel>();

                    trueData.Success = true;
                    trueData.City = data.City;
                    trueData.Country = data.Country_Name;
                    trueData.Ip = data.Ip;
                    trueData.Latitude = data.Latitude;
                    trueData.Longitude = data.Longitude;
                    trueData.RegionCode = data.Region_Name;
                    trueData.TimeZone = "N/A";
                    trueData.ZipCode = data.Zip;

                }
                else if (trueData.Success == false)
                {
                    trueData.City = "";
                    trueData.Country = "";
                    trueData.Ip = "";
                    trueData.RegionCode = "";
                    trueData.TimeZone = "";
                    trueData.ZipCode = "";
                    trueData.Longitude = null;
                    trueData.Latitude = null;
                }
                Console.Clear();

                // Shows which API was used, unless IpOrHostname is blank and ipstack is used
                // ip.api defaults to own ip if no IpOrHostname is specified
                if (apiChoice == 1)
                {
                    Console.WriteLine("API: ip.api");
                }
                else if (apiChoice == 2 && IpOrHostname != "")
                {
                    Console.WriteLine("API: api.ipstack");
                }
                else if (IpOrHostname == "")
                {
                    Console.WriteLine("Invalid query");
                }
                return trueData;
            }
        }
    }
}
